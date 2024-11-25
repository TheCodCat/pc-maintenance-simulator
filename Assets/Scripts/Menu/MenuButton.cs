using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using System;
using System.Threading;

public class MenuButton : MonoBehaviour
{
    public async void ResetToMenu(string name)
    {
        await SceneManager.LoadSceneAsync(name).ToUniTask();
    }
}
