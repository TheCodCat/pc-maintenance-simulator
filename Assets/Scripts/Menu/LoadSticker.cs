using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class LoadSticker : MonoBehaviour
{
    [SerializeField] public int _indexLevel;
    private const string _nameScene = "Game";
    private const string _nameSceneMenu = "Menu";
    private CancellationTokenSource _cancellationTokenSource;
    private CancellationToken _cancellationToken;

    public async void StartLoadSticker(SelectEnterEventArgs selectEnterEventArgs)
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = _cancellationTokenSource.Token;
        Debug.Log("Начинаю загрузку уровня");
        await UniTask.Delay(TimeSpan.FromSeconds(3f));

        await LoadStickerAsync(_indexLevel, _cancellationToken);
    }
    public void StopLoadSticker(SelectExitEventArgs selectExitEventArgs)
    {
        Debug.Log("Отмена");
        _cancellationTokenSource.Cancel();
    }

    public async UniTask LoadStickerAsync(int indexlevel, CancellationToken token)
    {
        if (!token.IsCancellationRequested)
        {
            StaticParametrs.IndexLevel = indexlevel;
            await SceneManager.LoadSceneAsync(_nameScene).ToUniTask();
        }
        else
        {
            _cancellationTokenSource.Dispose();
            return;
        }
    }

    public async void StartLoadStickerExit(SelectEnterEventArgs selectEnterEventArgs)
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = _cancellationTokenSource.Token;
        Debug.Log("Начинаю загрузку уровня");
        await UniTask.Delay(TimeSpan.FromSeconds(3f));

        await LoadStickerExitAsync( _cancellationToken);
    }
    public void StopLoadStickerExit(SelectExitEventArgs selectExitEventArgs)
    {
        Debug.Log("Отмена");
        _cancellationTokenSource.Cancel();
    }

    public async UniTask LoadStickerExitAsync(CancellationToken token)
    {
        if (!token.IsCancellationRequested)
        {
            await SceneManager.LoadSceneAsync(_nameSceneMenu).ToUniTask();
        }
        else
        {
            _cancellationTokenSource.Dispose();
            return;
        }
    }
}
