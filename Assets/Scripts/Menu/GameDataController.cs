using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Pipes;

public class GameDataController : MonoBehaviour
{
    public static GameDataController instance;
    [SerializeField] private bool[] SavesOpenKey;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        SavesOpenKey = LoadWin();
    }
    public void SaveWin()
    {
        string path = string.Empty;
#if UNITY_EDITOR
        path = "C:/Users/Public/saveload.gd";
#endif
#if !UNITY_EDITOR
        path = $"{Application.persistentDataPath}/saveload.gd";
#endif

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream;

        using (fileStream = File.Create(path))
        {
            bf.Serialize(fileStream, SavesOpenKey);
            fileStream.Close();
        }
    }
    public bool[] LoadWin()
    {
        string path = string.Empty;
#if UNITY_EDITOR
        path = "C:/Users/Public/saveload.gd";
#endif
#if !UNITY_EDITOR
        path = $"{Application.persistentDataPath}/saveload.gd";
#endif

        if (File.Exists($"C:/Users/Public/saveload.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open(path, FileMode.Open);
            bool[] bools = (bool[])bf.Deserialize(fileStream);
            fileStream.Close();
            return bools;
        }
        else
        {
            SaveWin();
            return SavesOpenKey;
        }
    }

    public void SetWinLvl(int index)
    {
        SavesOpenKey[index] = true;
    }
}
