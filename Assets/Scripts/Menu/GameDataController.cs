using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Create($"C:/Users/Public/saveload.gd");
        bf.Serialize(fileStream, SavesOpenKey);
        fileStream.Close();
    }
    public bool[] LoadWin()
    {
        if (File.Exists($"C:/Users/Public/saveload.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open($"C:/Users/Public/saveload.gd", FileMode.Open);
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
