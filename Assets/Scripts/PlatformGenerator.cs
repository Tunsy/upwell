using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    enum SpawningState
    {
        ROOMS,
        PLATFORMS
    }

    public List<GameObject> roomList;   //A list of prefabs of pre-defined collections of platforms
    public List<GameObject> platformList;   //A list of a la carte platforms used for "sprinkling" between rooms
    List<GameObject> currentPlatforms = new List<GameObject>();
    public float horizontalNoise = 0.5f;
    public float verticalSpacing = 5f;
    float yPos = 0;
    GameObject player;
    new Camera camera;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = Camera.main;
    }

    void Start()
    {
        Generate(10);
    }

    void Update()
    {
        //Debug.Log(camera.transform.position);
        if (currentPlatforms[currentPlatforms.Count-1].transform.position.y - camera.transform.position.y <= verticalSpacing * 2)
        {
            Generate(10);   
        }

        if (camera.transform.position.y - currentPlatforms[0].transform.position.y > verticalSpacing * 11)
        {
            DeletePlatforms(10);
        }
        //Debug.Log(platformList.Count)
    }

    public void Generate(int numOfPlatforms)
    {
        for (int i = 0; i < numOfPlatforms; i++)
        {
            //float xPos = Random.Range(-horizontalNoise, horizontalNoise);
            //float yPos = verticalSpacing * currentPlatforms.Count;
            float xPos = 0f;
            yPos += verticalSpacing;
            GameObject randomPlatform = platformList[Random.Range(0, platformList.Count)];
            GameObject newPlatform = (GameObject)Instantiate(randomPlatform, new Vector2(xPos, yPos), Quaternion.identity);
            PlatformInterface newPlatformScript = newPlatform.GetComponent<PlatformInterface>();
            if (newPlatformScript != null)
                newPlatformScript.Initialize();

            currentPlatforms.Add(newPlatform);
        }
    }

    public void DeletePlatforms(int numOfPlatforms)
    {
        for (int i = 0; i < numOfPlatforms; i++)
        {
            Destroy(currentPlatforms[0]);
            currentPlatforms.RemoveAt(0);
        }
    }
}
