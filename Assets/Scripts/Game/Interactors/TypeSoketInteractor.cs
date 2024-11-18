using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TypeSoketInteractor : XRSocketInteractor
{
    [SerializeField] private LevelController _levelController;
    [Header("Òåã ïğèñîåäèíåíèÿ")]
    [SerializeField] private TypePCSocket _typePCSocket;
    [Header("Óñëîâèÿ çàìåíû")]
    [SerializeField] private PCXRGrapInteractable _requiredÑomponent;

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        PCXRGrapInteractable component = interactable.transform.GetComponent<PCXRGrapInteractable>();
        return base.CanHover(interactable) && component.GetSocket().Equals(_typePCSocket);
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        PCXRGrapInteractable component = interactable.transform.GetComponent<PCXRGrapInteractable>();
        if (component.Equals(_requiredÑomponent))
        {
            _levelController.FixComponent();
        }
        return base.CanSelect(interactable) && component.GetSocket().Equals(_typePCSocket);
    }
}
