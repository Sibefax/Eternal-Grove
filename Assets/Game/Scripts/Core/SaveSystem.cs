using UnityEngine;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

[Serializable]
public class SettingsData
{
    public float masterVolume = 1f;
    public float musicVolume = 1f;
    public float sfxVolume = 1f;

    public bool fullscreen = true;
    public int resolutionWidth;
    public int resolutionHeight;
    public bool vSync = true;
}

[Serializable]
public class SaveData
{
    public SettingsData settings = new SettingsData();
}

[Serializable]
public class SaveContainer
{
    public SaveData data = new SaveData();
    public string hash;
}

public class SaveSystem : MonoBehaviour
{
    private const string Salt = "Q7v#P2mL!9xH@c4Rk8Yw$T5nB1zF6sAa";
    
    public void Awake()
    {
        LoadGame();
    }
    
    public SaveData Data { get; private set; } = new();

    private string SavePath =>
        Path.Combine(Application.persistentDataPath, "EternalGroveSave.json");

    public void SaveGame()
    {
        string dataJson = JsonUtility.ToJson(Data);

        SaveContainer container = new SaveContainer
        {
            data = Data,
            hash = CalculateHash(dataJson)
        };

        string saveJson = JsonUtility.ToJson(container, true);

        File.WriteAllText(SavePath, saveJson);
    }

    public void LoadGame()
    {
        try
        {
            if (!File.Exists(SavePath))
            {
                if (!File.Exists(SavePath))
                {
                    Data = new SaveData
                    {
                        settings = new SettingsData
                        {
                            resolutionWidth = Screen.currentResolution.width,
                            resolutionHeight = Screen.currentResolution.height
                        }
                    };

                    SaveGame();
                    return;
                }
            }

            string saveJson = File.ReadAllText(SavePath);

            SaveContainer container = JsonUtility.FromJson<SaveContainer>(saveJson);

            if (container == null || container.data == null)
            {
                throw new Exception("Save file is invalid.");
            }

            string dataJson = JsonUtility.ToJson(container.data);

            if (container.hash != CalculateHash(dataJson))
            {
                throw new Exception("Save hash verification failed.");
            }

            Data = container.data;
        }
        catch
        {
            if (File.Exists(SavePath))
                File.Delete(SavePath);

            Data = new SaveData();
            SaveGame();
        }
    }
    
    private string CalculateHash(string json)
    {
        using SHA256 sha = SHA256.Create();

        byte[] hash = sha.ComputeHash(
            Encoding.UTF8.GetBytes(json + Salt));

        return BitConverter
            .ToString(hash)
            .Replace("-", "");
    }
}