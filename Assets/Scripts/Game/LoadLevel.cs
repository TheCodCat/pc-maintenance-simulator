using System.Linq;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public static LoadLevel Instance;
    [SerializeField] private LevelController[] _levels;
    [SerializeField] private LevelController _currentLevel;
    public LevelController currentLevel => _currentLevel;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _levels[StaticParametrs.IndexLevel].gameObject.SetActive(true);
        _currentLevel = _levels[StaticParametrs.IndexLevel];
    }

    public void UpdateFixErrors()
    {
        _currentLevel.FixUpdateCount();
    }
    public void SetWinButton()
    {
        if(_currentLevel.GetCountErrors().Equals(_currentLevel.fixErrors))
            _currentLevel.SetWin();
    }
}
