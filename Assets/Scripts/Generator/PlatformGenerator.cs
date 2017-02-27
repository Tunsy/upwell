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
        Generate(10);
    }

    void Update()
    {
        //If the distance between the top and the camera position is less than twice the camera's height AKA if the top is less than two screens away.
        //Start generating a new chunk.
        if (this._topY - camera.transform.position.y <= 2 * cameraHeight)
            Generate(10);

        //If the lowest point is 3 screens away from the camera's current pos, start deleting objects
        if (camera.transform.position.y - this._bottomY > 3 * cameraHeight)
            _DespawnObjects();
        //Debug.Log(camera.transform.position);
        //if (currentPlatforms[currentPlatforms.Count-1].transform.position.y - camera.transform.position.y <= verticalSpacing * 2)
        //{
        //    Generate(10);   
        //}

        //if (camera.transform.position.y - currentPlatforms[0].transform.position.y > verticalSpacing * 11)
        //{
        //    DeletePlatforms(10);
        //}
        //Debug.Log(platformList.Count)
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

    private void _DespawnObjects()
    {

    }

    public void Generate(int numOfPlatforms)
    {
        for (int i = 0; i < numOfPlatforms; i++)
        {
            //float xPos = Random.Range(-horizontalNoise, horizontalNoise);
            //float yPos = verticalSpacing * currentPlatforms.Count;
            float xPos = 0f;
            float yPos = this._topY + verticalSpacing;
            GameObject randomPlatform = platformList[Random.Range(0, platformList.Count)];
            GameObject newPlatform = (GameObject)Instantiate(randomPlatform, new Vector2(xPos, yPos), Quaternion.identity);
            PlatformInterface newPlatformScript = newPlatform.GetComponent<PlatformInterface>();
            if (newPlatformScript != null)
                newPlatformScript.Initialize();

            //currentPlatforms.Add(newPlatform);
            generatedObjects.Enqueue(newPlatform);
        }
    }

    //public void DeletePlatforms(int numOfPlatforms)
    //{
    //    for (int i = 0; i < numOfPlatforms; i++)
    //    {
    //        Destroy(currentPlatforms[0]);
    //        currentPlatforms.RemoveAt(0);
    //    }
    //}
}
