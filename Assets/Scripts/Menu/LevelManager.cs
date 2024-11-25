using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable[] _levelButtons;

    private void Start()
    {
        bool[] bools = GameDataController.instance.LoadWin();

        for (int i = 0; i < _levelButtons.Length; i++) 
        {
            Debug.Log(i);
            _levelButtons[i].gameObject.SetActive(bools[i]);
        }
    }
}
