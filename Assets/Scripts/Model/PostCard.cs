using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostCard : MonoBehaviour, IPost, IActivated
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;
    [Header("Текстовая ошибка")]
    [SerializeField] private Text _text;
    [SerializeField] private string _title;

    public void Activate()
    {
        ActivePost(_audioClip);
        _text.text = _title;
    }
    public void Deactivate()
    {
        _text.text = string.Empty;
    }

    public void ActivePost(AudioClip post)
    {
        _audioSource.clip = post;
        _audioSource?.Play();
    }

}
