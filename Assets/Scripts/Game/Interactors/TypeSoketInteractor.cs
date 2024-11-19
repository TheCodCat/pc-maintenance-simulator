using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TypeSoketInteractor : XRSocketInteractor
{
    [SerializeField] private LevelController _levelController;
    [Header("Òåã ïğèñîåäèíåíèÿ")]
    [SerializeField] private TypePCSocket _typePCSocket;
    [Header("Çàâèñÿùèå êîìïîíåíòû")]
    [SerializeField] private TypeSoketInteractor _lastSelectableÑomponent;
    [SerializeField, Tooltip("Íóæíî ëè óñòàíîâèòü äğóãîé êîìïîíåíò äëÿ óñòàíîâêè")] private bool _isSelectable;
    [SerializeField] private bool _isSetup;
    [Header("Óñëîâèÿ çàìåíû")]
    [SerializeField] private PCXRGrapInteractable _requiredÑomponent;
    [SerializeField, Tooltip("Íóæíà ëè çàìåíà äà/íåò")] protected bool _required;
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


    private PCXRGrapInteractable _currentÑomponent;

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        PCXRGrapInteractable component = interactable.transform.GetComponent<PCXRGrapInteractable>();
        bool isSetup = _lastSelectableÑomponent != null ? _lastSelectableÑomponent.IsSetup : true;
        return base.CanHover(interactable) && component.GetSocket().Equals(_typePCSocket) && isSetup;
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        _currentÑomponent = interactable.transform.GetComponent<PCXRGrapInteractable>();
        bool isSetup = _lastSelectableÑomponent != null ? _lastSelectableÑomponent.IsSetup : true;
        return base.CanSelect(interactable) && _currentÑomponent.GetSocket().Equals(_typePCSocket) && isSetup;
    }

    public void onSelected(SelectEnterEventArgs selectEnterEventArgs)
    {
        IsSetup = true;
    }
    public void OnDeselected(SelectExitEventArgs selectExitEventArgs)
    {
        IsSetup = false;
    }
    public void FixSelectable(SelectEnterEventArgs selectEnterEventArgs)
    {
        if (!_required) return;
        if (_requiredÑomponent.Equals(_currentÑomponent))
        {
            Debug.Log($"asdasd {gameObject.name}");
            _levelController.FixComponent();
        }
    }
    public void UnFixSelectable(SelectExitEventArgs selectExitEventArgs)
    {
        if (!_required) return;
        if (_requiredÑomponent.Equals(_currentÑomponent))
        {
            Debug.Log($"asdasd {gameObject.name}");
            _levelController.UnFixComponent();
        }
    }
}
