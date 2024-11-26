using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PCXRGrapInteractable : XRGrabInteractable
{
    [SerializeField] private TypePCSocket _socket;
    [SerializeField] private Transform _panel;
    [Header("Звуки подбора и выброса")]
    [SerializeField] private AudioClip _audioClipSelect;
    [SerializeField] private AudioClip _audioClipDeselect;
    [SerializeField] private AudioSource _audioSource;
    private Transform _target;

    private CancellationTokenSource _cancellationTokenSource;
    private CancellationToken _cancellationToken;


    public TypePCSocket GetSocket()
    {
        return _socket;
    }

    public async void OnActivate(ActivateEventArgs selectEnterEventArgs)
    {
        _panel.gameObject.SetActive(true);
        _cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = _cancellationTokenSource.Token;

        _target = Player.Instance.GetCamera();
        await LookAtPlayer(_cancellationToken);
    }
    public void OnDeactivate(DeactivateEventArgs selectEnterEventArgs)
    {
        _panel.gameObject.SetActive(false);
        _cancellationTokenSource.Cancel();
    }

    public void OnSelected(SelectEnterEventArgs selectEnterEventArgs)
    {
        _audioSource.clip = _audioClipSelect;
        _audioSource?.Play();
    }
    public void OnDeSelected(SelectExitEventArgs selectExitEventArgs)
    {
        _audioSource.clip = _audioClipDeselect;
        _audioSource.Play();
    }

    private async UniTask LookAtPlayer(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            _cancellationTokenSource.Dispose();
            return;
        }
        else
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _panel?.LookAt(_target);
                await UniTask.Yield();
            }
        }
    }
}
