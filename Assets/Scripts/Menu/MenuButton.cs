using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using System;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private string _nameScene;
    [SerializeField] private CameraView _cameraView;
    public async void LevelLoad(int indexlevel)
    {
        StaticParametrs.IndexLevel = indexlevel;
        await _cameraView.ChangeView(ViewMode.Enable);
        await SceneManager.LoadSceneAsync(_nameScene).ToUniTask();
    }
}
