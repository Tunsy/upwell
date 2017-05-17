using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{

    //public GameObject wall;
    public GameObject walls;
    public GameObject room;
    private BoxCollider2D roomCol;
    private float height;
    private PlayerController player;
    public List<GameObject> currentRooms;


    // Use this for initialization
    void Start()
    {
        height = 2f * Camera.main.orthographicSize;
        roomCol = walls.GetComponent<BoxCollider2D>();
        player = FindObjectOfType<PlayerController>();
        //tileSize = new Vector2(background.GetComponent<Collider2D>().bounds.size.x, background.GetComponent<Collider2D>().bounds.size.y);
        //topPosition = new Vector2(topFloor.transform.position.x - topFloor.GetComponent<Collider2D>().bounds.size.x, topFloor.transform.position.y - topFloor.GetComponent<Collider2D>().bounds.size.y);
        //bottomPosition = new Vector2(bottomFloor.transform.position.x - bottomFloor.GetComponent<Collider2D>().bounds.size.x, bottomFloor.transform.position.y - bottomFloor.GetComponent<Collider2D>().bounds.size.y);

        //int num = (int)Mathf.Round((topPosition.y - bottomPosition.y) / tileSize.y);
        //GameObject child;
        //for(int i = 0; i < num; i++)
        //{
        //        //child = Instantiate(layer) as GameObject;
        //        //child.transform.position = transform.position - (new Vector3(spriteSize.x * j, spriteSize.y * i, 0)
        //        //    - new Vector3(0, transform.localScale.y == 1 ? 0 : (1 / 2f * sprite.bounds.size.y), 0)
        //        //    - new Vector3(col.bounds.size.x / 2, col.bounds.size.y / 2, 0)
        //        //    + new Vector3(spriteSize.x / 2, spriteSize.y / 2, 0));
        //        //child.transform.parent = transform;
        //}


    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            GenerateRoomIfRequired();
        }
    }

    void AddRoom(float farthestRoomEndY)
    {

        float roomHeight = roomCol.size.y;
        float roomCenter = farthestRoomEndY + roomHeight * 0.5f;
        GameObject roomInstance = (GameObject)Instantiate(room);
        roomInstance.transform.position = new Vector3(transform.position.x, roomCenter, 0);
        currentRooms.Add(roomInstance);
    }

    void GenerateRoomIfRequired()
    {
        bool addRooms = true;
        float playerY = player.transform.position.y;
        float addRoomY = playerY + height;
        float farthestRoomEndY = 0;

        foreach (var room in currentRooms)
        {
            //7
            float roomHeight = roomCol.size.y;
            float roomStartY = room.transform.position.y - (roomHeight * 0.5f);
            float roomEndY = roomStartY + roomHeight;

            //8
            if (roomStartY > addRoomY)
                addRooms = false;

            //10
            farthestRoomEndY = Mathf.Max(farthestRoomEndY, roomEndY);
        }

        //12
        if (addRooms)
            AddRoom(farthestRoomEndY);
    }
}
