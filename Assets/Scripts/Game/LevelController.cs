using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    [SerializeField] private TypeSoketInteractor[] _errors;
    [SerializeField] private TypeSoketInteractor[] _allSoket;
    [SerializeField] private LevelController _openWinLvl;
    [SerializeField] private int _fixErrors;
    [Header("Звук выигрыша")]
    [SerializeField] private AudioSource _source;
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
    }
    public void UnFixComponent()
    {
        fixErrors--;
        fixErrors = Mathf.Clamp(fixErrors, 0, _errors.Length);
    }

    public void FixUpdateCount()
    {
        int setupCount = _allSoket.Where(i => i.IsSetup).Count();
        if (_fixErrors.Equals(_errors.Length) && _allSoket.Length.Equals(setupCount))
        {
            Debug.Log("Победа");
            _openWinLvl?.SetWin();
            _source?.Play();
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
