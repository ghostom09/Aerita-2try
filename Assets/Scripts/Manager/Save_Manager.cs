using UnityEngine;
using System.IO;

public class Save_Manager
{
    private static Save_Manager instance;

    public static Save_Manager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Save_Manager();
            }
            return instance;
        }
    }
    
    private string _savePath = Application.persistentDataPath + "/save.json";

    public void Save(Game_Data data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(_savePath, json);
    }

    public Player_Data Load()
    {
        if (!File.Exists(_savePath))
        {
            return new Player_Data();
        }

        string json = File.ReadAllText(_savePath);
        Player_Data data = JsonUtility.FromJson<Player_Data>(json);
        return data;
    }
}
