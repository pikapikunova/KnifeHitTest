using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad
{
    private string path;
    private BinaryFormatter formatter;

    public SaveLoad()
    {
        path = Application.persistentDataPath + "/data.save";
        formatter = new BinaryFormatter();
    }

    public void SaveGame(object saveData)
    {
        var file = File.Create(path);
        formatter.Serialize(file, saveData);
        file.Close();
    }

    public object LoadGame(object saveData)
    {
        
        if (!File.Exists(path))
        {
            if (saveData != null)
                SaveGame(saveData);
            return saveData;
        }
        

        var file = File.Open(path, FileMode.Open);
        object data = formatter.Deserialize(file);
        file.Close();

        return data;

    }

}
