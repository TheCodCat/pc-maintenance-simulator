using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TypeSoketInteractor : XRSocketInteractor
{
    [Header("Òåã ïğèñîåäèíåíèÿ")]
    [SerializeField] private TypePCSocket _typePCSocket;
    [SerializeField] private ParticleSystem _particleSystem;
    [Header("Çàâèñÿùèå êîìïîíåíòû")]
    [SerializeField, Tooltip("Êîìïîíåíò çàâèñèò îò âûáğàííîãî êîìïîíåíòà")] private TypeSoketInteractor _lastSelectableÑomponent;
    private bool _isSetup;
    [Header("Óñëîâèÿ çàìåíû")]
    [SerializeField] private PCXRGrapInteractable _requiredÑomponent;
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
        _particleSystem?.Play();
        if (selectEnterEventArgs.interactableObject.transform.TryGetComponent(out IActivated component))
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
        try
        {
            if (_requiredÑomponent is null) return;
            if (_requiredÑomponent.Equals(_currentÑomponent))
            {
                Debug.Log($"asdasd {gameObject.name}");
                LoadLevel.Instance.currentLevel.FixComponent();
            }
        }
        catch(NullReferenceException)
        {
            Debug.Log(gameObject.name);
        }
    }
    public void UnFixSelectable(SelectExitEventArgs selectExitEventArgs)
    {
        if (_requiredÑomponent is null) return;
        if (_requiredÑomponent.Equals(_currentÑomponent))
        {
            Debug.Log($"asdasd {gameObject.name}");
            LoadLevel.Instance.currentLevel.UnFixComponent();
        }
    }

}
