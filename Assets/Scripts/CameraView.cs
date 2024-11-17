using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CameraView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private AnimationCurve _animationCurveDisable;
    [SerializeField] private AnimationCurve _animationCurveEnable;
    [SerializeField] private float _time;

    private async void Start()
    {
        await ChangeView(ViewMode.Disable);
    }

    public async UniTask<bool> ChangeView(ViewMode viewMode = ViewMode.Disable)
    {
        Color color = new Color(0,0,0);

        while(_time < _animationCurveDisable.keys[_animationCurveDisable.length - 1].time)
        {
            switch (viewMode)
            {
                case ViewMode.Disable:

                color.a = _animationCurveDisable.Evaluate(_time);
                _time += Time.deltaTime;
                _image.color = color;
                break;
                //--------------------------
                case ViewMode.Enable:

                color.a = _animationCurveEnable.Evaluate(_time);
                _time += Time.deltaTime;
                _image.color = color;
                break;
            }
            _time += Time.deltaTime;
            Debug.Log(_time);
            await UniTask.Yield();
        }
        Debug.Log(true);
        return true;
    }
}
public enum ViewMode
{
    Enable, Disable
}
