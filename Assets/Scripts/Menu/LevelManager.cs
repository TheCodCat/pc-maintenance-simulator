using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] _levelButtons;

    private void Start()
    {
        bool[] bools = GameDataController.instance.LoadWin();

        for (int i = 0; i < _levelButtons.Length; i++) 
        {
            Debug.Log(i);
            _levelButtons[i].interactable = bools[i];
        }
    }
}
