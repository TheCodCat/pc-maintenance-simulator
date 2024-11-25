using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField] private int _errorsCount;

    private void OnEnable()
    {
        LevelController.OnFixedChange += UpdateTextErrors;
    }
    private void OnDisable()
    {
        LevelController.OnFixedChange -= UpdateTextErrors;
    }

    private void UpdateTextErrors(int fix = 0)
    {
        string _text = $"{fix}/{LoadLevel.Instance.currentLevel.GetCountErrors()}";
        Debug.Log(_text);
    }

}
