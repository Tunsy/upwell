using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    public GameObject platform;
    new Camera camera;
    public float horizontalNoise = 0.5f;
    public float verticalSpacing = 5f;
    List<GameObject> platformList = new List<GameObject>();
    GameObject player;

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
        Debug.Log(camera.transform.position);
        if (platformList[platformList.Count-1].transform.position.y - camera.transform.position.y <= verticalSpacing * 2)
        {
            Generate(10);
        }
        //Debug.Log(platformList.Count)
    }

    public void Generate(int numOfPlatforms)
    {
        for (int i = 0; i < numOfPlatforms; i++)
        {
            float xPos = Random.Range(-horizontalNoise, horizontalNoise);
            float yPos = verticalSpacing * platformList.Count;
            GameObject newPlatform = (GameObject)Instantiate(platform, new Vector2(xPos, yPos), Quaternion.identity);
            platformList.Add(newPlatform);
        }
    }
}
