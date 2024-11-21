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
    [Header("��������� ����������")]
    [SerializeField, Tooltip("��������� ������� �� ���������� ����������")] private TypeSoketInteractor _lastSelectable�omponent;
    private bool _isSetup;
    [Header("������� ������")]
    [SerializeField] private PCXRGrapInteractable _required�omponent;
    [SerializeField, Tooltip("����� �� ������ ��/���")] protected bool _required;
    public bool IsSetup
    {
        get
        {
            return _isSetup;
        }
        set
        {
            _isSetup = value;
        }
    }


    private PCXRGrapInteractable _current�omponent;

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        PCXRGrapInteractable component = interactable.transform.GetComponent<PCXRGrapInteractable>();
        bool isSetup = _lastSelectable�omponent != null ? _lastSelectable�omponent.IsSetup : true;
        return base.CanHover(interactable) && component.GetSocket().Equals(_typePCSocket) && isSetup;
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        _current�omponent = interactable.transform.GetComponent<PCXRGrapInteractable>();
        bool isSetup = _lastSelectable�omponent != null ? _lastSelectable�omponent.IsSetup : true;
        return base.CanSelect(interactable) && _current�omponent.GetSocket().Equals(_typePCSocket) && isSetup;
    }

    public void onSelected(SelectEnterEventArgs selectEnterEventArgs)
    {
        IsSetup = true;

        if(selectEnterEventArgs.interactableObject.transform.TryGetComponent(out IActivated component))
        {
            component.Activate();
        }
    }
    public void OnDeselected(SelectExitEventArgs selectExitEventArgs)
    {
        IsSetup = false;

        if (selectExitEventArgs.interactableObject.transform.TryGetComponent(out IActivated component))
        {
            component.Deactivate();
        }
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
