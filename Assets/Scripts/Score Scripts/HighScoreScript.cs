using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class HighScoreScript : MonoBehaviour {

    private int score;
    private static int highscore;
    public Text text;

    void Start()
    {
        text = this.GetComponent<Text>();
        Load();
    }

    void Update()
    {
        score = GameManager.instance.getPlayerScore();
        if (score > highscore)
        {
            highscore = score;
            Save();
        }
        text.text = "High Score: " + highscore;
    }

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/highscore.gd");

        HighScoreData data = new HighScoreData();
        data.highscore = highscore;

        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/highscore.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/highscore.gd", FileMode.Open);

            HighScoreData data = (HighScoreData)bf.Deserialize(file);
            file.Close();

            highscore = data.highscore;
        }
    }
}

[System.Serializable]
class HighScoreData
{
    public int highscore;
}
