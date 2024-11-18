using System.Linq;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] _levels;
    private void Start()
    {
        GameObject[] activeLevels = _levels.Where(x => x.gameObject.activeSelf).ToArray();
        Debug.Log(activeLevels.Length);
        if(activeLevels.Length is not 0)
        {
            foreach (var item in activeLevels)
            {
                item.gameObject.SetActive(false);
            }
        }

        _levels[StaticParametrs.IndexLevel].gameObject.SetActive(true);
    }
}
