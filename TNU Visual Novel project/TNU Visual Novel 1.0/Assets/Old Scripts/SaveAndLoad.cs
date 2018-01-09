using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveAndLoad : MonoBehaviour {

    public static SaveAndLoad saveAndLoad;

    //public TextChange colourText;
    public float textCount;

    void Awake()
    {
        // Also I can use Awake if I use autosaving with OnEnable and OnDisable.

        if (saveAndLoad == null)
        {
            DontDestroyOnLoad(gameObject);
            saveAndLoad = this;
        } else if (saveAndLoad != this)
        {
            Destroy(gameObject);
        }
    }

    public void Save() // Change to Save 1 and created Save 2, 3, 4 for other save slots.
    {
        print("Start saving");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat"); // Change the file name to something better and add a 1 to the end for the save slots.

        PlayerData data = new PlayerData();
        data.textCount = textCount;
        //data.colourText = colourText;
        // data.experience = experience;


        bf.Serialize(file, data);
        file.Close();
        print("Game saved");
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            data.textCount = textCount;
            // data.colourText = colourText;
            // data.experience = experience;
            print("Game Loaded");
        }
    }
    
}

[Serializable]
class PlayerData
{
    public float textCount; // Shouldn't be a float. What does it need to be?
  //  public float experince;
}
