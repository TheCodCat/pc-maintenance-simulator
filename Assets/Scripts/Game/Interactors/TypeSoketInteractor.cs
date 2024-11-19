using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TypeSoketInteractor : XRSocketInteractor
{
    [SerializeField] private LevelController _levelController;
    [Header("��� �������������")]
    [SerializeField] private TypePCSocket _typePCSocket;
    [Header("������� ������")]
    [SerializeField] private PCXRGrapInteractable _required�omponent;
    [SerializeField, Tooltip("����� �� ������ ��/���")] protected bool _required;

    private PCXRGrapInteractable _current�omponent;

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        PCXRGrapInteractable component = interactable.transform.GetComponent<PCXRGrapInteractable>();
        return base.CanHover(interactable) && component.GetSocket().Equals(_typePCSocket);
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        _current�omponent = interactable.transform.GetComponent<PCXRGrapInteractable>();

        return base.CanSelect(interactable) && _current�omponent.GetSocket().Equals(_typePCSocket);
    }
    public void FixSelectable(SelectEnterEventArgs selectEnterEventArgs)
    {
        if (!_required) return;
        if (_required�omponent.Equals(_current�omponent))
        {
            Debug.Log($"asdasd {gameObject.name}");
            _levelController.FixComponent();
        }
    }
    public void UnFixSelectable(SelectExitEventArgs selectExitEventArgs)
    {
        if (!_required) return;
        if (_required�omponent.Equals(_current�omponent))
        {
            Debug.Log($"asdasd {gameObject.name}");
            _levelController.UnFixComponent();
        }
    }
}
