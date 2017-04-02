using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class BestTimeScript : MonoBehaviour {

    public GameObject GameOverScreen;
    private int time;
    private static int besttime;
    public Text text;

    void Start()
    {
        text = this.GetComponent<Text>();
        Load();
    }

    void Update()
    {
        time = (int)GameManager.instance.timeElapsed();
        if (GameOverScreen.activeInHierarchy)
        {
            Changetime();
        }
    }

    void Changetime()
    {
        if (time < besttime)
        {
            besttime = time;
            Save();
        }
        text.text = "Best Time: " + besttime;
    }

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");

        BestTimeData data = new BestTimeData();
        data.besttime = besttime;

        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);

            BestTimeData data = (BestTimeData)bf.Deserialize(file);
            file.Close();

            besttime = data.besttime;
        }
    }
}

class BestTimeData
{
    public int besttime;
}