using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    [SerializeField] private GameObject _attachPoint;

    public void ActivateAttach(SelectEnterEventArgs selectEnterEventArgs) =>
        _attachPoint?.SetActive(false);
    public void DeactivateDetach(SelectExitEventArgs selectExitEventArgs) =>
        _attachPoint?.SetActive(true);

}
