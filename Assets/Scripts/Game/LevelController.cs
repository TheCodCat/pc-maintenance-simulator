using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    public static UnityAction<int> OnFixedChange;
    [SerializeField] private TypeSoketInteractor[] _errors;
    [SerializeField] private LevelController _openWinLvl;
    [SerializeField] private int _fixErrors;
    public int fixErrors
    {
        get
        {
            return _fixErrors;
        }
        set
        {
            _fixErrors = value;
        }
    }
    public void FixComponent()
    {
        fixErrors++;
        fixErrors = Mathf.Clamp(fixErrors,0, _errors.Length);
        FixUpdateCount();
    }
    public void UnFixComponent()
    {
        fixErrors--;
        fixErrors = Mathf.Clamp(fixErrors, 0, _errors.Length);
        FixUpdateCount();
    }

    public void FixUpdateCount()
    {
        OnFixedChange?.Invoke(fixErrors);
        if (_fixErrors.Equals(_errors.Length))
        {
            Debug.Log("Победа");
            _openWinLvl.SetWin();   
        }
    }
    public int GetCountErrors()
    {
        return _errors.Length;
    }

    public void SetWin()
    {
        Debug.Log("Уровень решен");
        Debug.Log(_openWinLvl.gameObject.name);
        GameDataController.instance.SetWinLvl(LoadLevel.Instance.GetIndexLvl(this));
        GameDataController.instance.SaveWin();
    }
}
