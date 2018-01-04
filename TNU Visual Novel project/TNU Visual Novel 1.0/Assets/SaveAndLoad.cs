using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveAndLoad : MonoBehaviour {

    public static SaveAndLoad saveAndLoad;

    public float colourText;

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

    public void Save()
    {
        print("Start saving");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.colourText = colourText;
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

            data.colourText = colourText;
            // data.experience = experience;
            print("Game Loaded");
        }
    }
    
}

[Serializable]
class PlayerData
{
    public float colourText; // Shouldn't be a float. What does it need to be?
  //  public float experince;
}
