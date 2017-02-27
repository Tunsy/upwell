using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    enum SpawnType
    {
        NONE,
        ROOM,
        PLATFORM
    }

    public List<GameObject> roomList;   //A list of prefabs of pre-defined collections of platforms
    public List<GameObject> platformList;   //A list of a la carte platforms used for "sprinkling" between rooms
    public GameObject transitionPlatform; //A platform used to transitioning from random sprinkling back to pre-defined rooms.
    public float verticalSpacing = 5f;  //A public float dictating how far to spread platforms from each other.

    /// <summary>
    /// A queue of all objects that have been spawned. Used for state tracking and destroy objects.
    /// .front() returns the highest (most recently spawned) 
    /// </summary>
    Queue<GameObject> generatedObjects = new Queue<GameObject>();
    GameObject firstPlatform;
    GameObject player;
    new Camera camera;
    float cameraHeight;

    //float topY = 0, bottomY = 0;   //Floats used to keep track where the y-positions of ends of the queue are at.
    //List<GameObject> currentPlatforms = new List<GameObject>();
    //public float horizontalNoise = 0.5f;
    //float yPos = 0;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = Camera.main;
        cameraHeight = 2 * camera.orthographicSize;
    }

    void Start()
    {
        firstPlatform = this.transform.Find("FirstPlatform").gameObject;
        generatedObjects.Enqueue(firstPlatform);
        Generate();
    }

    void Update()
    {
        //If the distance between the top and the camera position is less than twice the camera's height AKA if the top is less than two screens away.
        //Start generating a new chunk.
        if (this._DistanceFromTop <= 2 * cameraHeight)
            Generate();

        //If the lowest point is 5 screens away from the camera's current pos, start deleting objects
        if (this._DistanceFromBottom > 5 * cameraHeight)
            _DespawnObjects();
    }

    /// <summary>
    /// Returns the y-position of the highest (most recently generated) object.
    /// </summary>
    private float _topY
    {
        get
        {
            GameObject topObject = generatedObjects.Last(); //Newest object in the queue
            SpawnType objectType = _CheckObject(topObject);
            if (objectType == SpawnType.ROOM)   //If it's a room, return the highest child object.
            {
                return topObject.GetComponent<Room>().topY;
            }
            else if (objectType == SpawnType.PLATFORM)  //If it's a platform, just return the y-position of that platform.
            {
                return topObject.transform.position.y;
            }
            else
            {
                //TODO : This should never get called
                Debug.LogWarning("PlatformGenerator: No spawnable object in generatedObjects queue.");
                return float.MinValue;
            }
        }
    }

    /// <summary>
    /// Returns the y-position of the lowest (oldest generated) object.
    /// </summary>
    private float _bottomY
    {
        get
        {
            GameObject bottomObject = generatedObjects.First(); //Oldest object in the queue
            /* Regardless if the object is a room or a platform, the y-position should be the lowest point
            If it's a platform - just return it's position
            If it's a room - the location of the parent of the room object should also be the world location of the lowest child. */
            return bottomObject.transform.position.y;
        }
    }

    /// <summary>
    /// Returns whether the object is a room or a platform
    /// </summary>
    private SpawnType _CheckObject(GameObject spawnableObject)
    {
        if (spawnableObject.GetComponent<PlatformInterface>() != null)
            return SpawnType.PLATFORM;
        else if (spawnableObject.GetComponent<Room>())
            return SpawnType.ROOM;
        else
            return SpawnType.NONE;
    }

    /// <summary>
    /// Tries to delete the bottom most object. Returns false if the object is a room that the player is still in.
    /// </summary>
    private bool _DespawnOne()
    {
        GameObject bottomObject = generatedObjects.First();
        SpawnType objectType = _CheckObject(bottomObject);
        if (objectType == SpawnType.PLATFORM)
        {
            generatedObjects.Dequeue();
            Destroy(bottomObject);
        }
        else if (objectType == SpawnType.ROOM)
        {
            float padSpace = cameraHeight / 2;
            Room roomScript = bottomObject.GetComponent<Room>();
            if (roomScript.topY + padSpace >= player.transform.position.y)
            {
                return false;
            }
            else
            {
                generatedObjects.Dequeue();
                Destroy(bottomObject);
            }
        }

        return true;
    }

    /// <summary>
    /// Delete objects at the bottom more than 3 screens away. Stop after the bottom-most object is 3 screens away.
    /// </summary>
    private void _DespawnObjects()
    {
        while (this._DistanceFromBottom > 3 * cameraHeight)
        {
            bool tryDelete = _DespawnOne();
            if (tryDelete == false)
                break;
        }
    }

    public void Generate()
    {
        while (this._DistanceFromTop < 5 * cameraHeight)
        {
            float yPos = this._topY + verticalSpacing;
            GameObject randomPlatform = platformList[Random.Range(0, platformList.Count)];
            GameObject newPlatform = (GameObject)Instantiate(randomPlatform, new Vector2(0, yPos), Quaternion.identity);
            PlatformInterface newPlatformScript = newPlatform.GetComponent<PlatformInterface>();
            if (newPlatformScript != null)
                newPlatformScript.Initialize();

            generatedObjects.Enqueue(newPlatform);
        }
        //for (int i = 0; i < numOfPlatforms; i++)
        //{
        //    //float xPos = Random.Range(-horizontalNoise, horizontalNoise);
        //    //float yPos = verticalSpacing * currentPlatforms.Count;
        //    float xPos = 0f;
        //    float yPos = this._topY + verticalSpacing;
        //    GameObject randomPlatform = platformList[Random.Range(0, platformList.Count)];
        //    GameObject newPlatform = (GameObject)Instantiate(randomPlatform, new Vector2(xPos, yPos), Quaternion.identity);
        //    PlatformInterface newPlatformScript = newPlatform.GetComponent<PlatformInterface>();
        //    if (newPlatformScript != null)
        //        newPlatformScript.Initialize();

        //    //currentPlatforms.Add(newPlatform);
        //    generatedObjects.Enqueue(newPlatform);
        //}
    }

    private SpawnType _ChooseRoomOrPlatform(float roomWeight=50, float platformWeight=50)
    {
        SpawnType higherWeight = SpawnType.ROOM;
        SpawnType lowerWeight = SpawnType.PLATFORM;
        if (roomWeight >= platformWeight)
        {
            higherWeight = SpawnType.ROOM;
            lowerWeight = SpawnType.PLATFORM;
        }
        else
        {
            higherWeight = SpawnType.PLATFORM;
            lowerWeight = SpawnType.ROOM;
        }

        float randFloat = Random.Range(0, roomWeight + platformWeight);
        if (randFloat <= Mathf.Max(roomWeight, platformWeight))
            return higherWeight;
        else
            return lowerWeight;
    }

    float _DistanceFromTop
    {
        get
        {
            return this._topY - camera.transform.position.y;
        }
    }

    float _DistanceFromBottom
    {
        get
        {
            return camera.transform.position.y - this._bottomY;
        }
    }
}
