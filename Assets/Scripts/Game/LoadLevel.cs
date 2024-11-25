using System.Collections.Generic;
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

    public int GetIndexLvl(LevelController levelController)
    {
        IList<LevelController> levels = _levels;
        int index = levels.IndexOf(levelController);
        Debug.Log(index);
        return index;
    }
}
