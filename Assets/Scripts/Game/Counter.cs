using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Counter : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private Text _fixText;
    [SerializeField] private Text _CountErrorstext;
    private const string ACTIVE_KEY = "Active";
    private int _fixCount;

    public void Selected(SelectEnterEventArgs selectEnterEventArgs)
    {
        _animator.SetTrigger(ACTIVE_KEY);
    }
    public void EventClick()
    {
        _fixCount = LoadLevel.Instance.currentLevel.fixErrors;
        _fixText.text = _fixCount.ToString();
        _CountErrorstext.text = LoadLevel.Instance.currentLevel.GetCountErrors().ToString();

        string _text = $"{_fixCount}/{LoadLevel.Instance.currentLevel.GetCountErrors()}";

        LoadLevel.Instance.currentLevel.FixUpdateCount();

        Debug.Log(_text);
    }

    public void ClickPlay()
    {
        if (_audioSource != null)
        {
            _audioSource.clip = _audioClip;
            _audioSource.Play();
        }
    }
}
