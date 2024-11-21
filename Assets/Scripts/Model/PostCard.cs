using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PostCard : MonoBehaviour, IPost, IActivated
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;

    public void Activate()
    {
        ActivePost(_audioClip);
    }
    public void Deactivate()
    {
    }

    public void ActivePost(AudioClip post)
    {
        _audioSource.clip = post;
        _audioSource.Play();
    }

}
