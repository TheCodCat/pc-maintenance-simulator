using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using System;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private string _nameScene;
    [SerializeField] private AudioClip _audioClip;
    public async void LevelLoad(int indexlevel)
    {
        StaticParametrs.IndexLevel = indexlevel;
        await SceneManager.LoadSceneAsync(_nameScene).ToUniTask();
    }
    public async void ResetToMenu(string name)
    {
        await SceneManager.LoadSceneAsync(name).ToUniTask();
    }
    public void AudioSelect()
    {
        AudioSource.PlayClipAtPoint(_audioClip,transform.position,0.3f);
    }
}
