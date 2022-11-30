using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    public string PlayerName;

    public float Wave;
    public float VolumeMusic;
    public float VolumeEffects;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadNameAndScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public float Wave;
        public float VolumeMusic;
        public float VolumeEffects;
    }

    public void SaveNameAndScore()
    {
        SaveData data = new SaveData();

        data.PlayerName = PlayerName;
        data.Wave = Wave;
        data.VolumeMusic = VolumeMusic;
        data.VolumeEffects = VolumeEffects;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNameAndScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {

            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            Wave = data.Wave;
            VolumeMusic = data.VolumeMusic;
            VolumeEffects = data.VolumeEffects;
        }
    }

}
