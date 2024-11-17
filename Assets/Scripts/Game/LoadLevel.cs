using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] _levels;
    private void Start()
    {
        _levels[StaticParametrs.IndexLevel].SetActive(true);
    }
}
