using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    public static UnityAction<int> OnFixedChange;
    [SerializeField] private TypeSoketInteractor[] _errors;
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
            OnFixedChange?.Invoke(value);
        }
    }
    public void FixComponent()
    {
        fixErrors++;
        fixErrors = Mathf.Clamp(fixErrors,0, _errors.Length);
        OnFixedChange?.Invoke(fixErrors);
    }
    public void UnFixComponent()
    {
        fixErrors--;
        fixErrors = Mathf.Clamp(fixErrors, 0, _errors.Length);
        OnFixedChange?.Invoke(fixErrors);
    }
    public int GetCountErrors()
    {
        return _errors.Length;
    }
}
