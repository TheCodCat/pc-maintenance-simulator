using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using System;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private string _nameScene;
    public async void LevelLoad(int indexlevel)
    {
        StaticParametrs.IndexLevel = indexlevel;
        await SceneManager.LoadSceneAsync(_nameScene).ToUniTask();
    }
    public async void ResetToMenu(string name)
    {
        await SceneManager.LoadSceneAsync(name).ToUniTask();
    }
}
