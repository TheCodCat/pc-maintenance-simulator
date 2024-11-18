using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField] private Text _errorsText;
    [SerializeField] private LevelController _levelController;
    [SerializeField] private int _errorsCount;

    private void OnEnable()
    {
        LevelController.OnFixedChange += UpdateTextErrors;
    }
    private void OnDisable()
    {
        LevelController.OnFixedChange -= UpdateTextErrors;
    }

    private void UpdateTextErrors(int fix)
    {
        _errorsText.text = $"{fix}/{_levelController.GetCountErrors()}";
    }

}