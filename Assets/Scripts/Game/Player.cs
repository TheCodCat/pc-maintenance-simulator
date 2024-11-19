using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    [SerializeField] private Transform _camera;
    private void Awake()
    {
        Instance = this;
    }
    public Transform GetCamera() => _camera;
}
