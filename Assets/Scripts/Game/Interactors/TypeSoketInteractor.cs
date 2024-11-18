using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TypeSoketInteractor : XRSocketInteractor
{
    [SerializeField] private TypePCSocket _typePCSocket;

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        PCXRGrapInteractable component = interactable.transform.GetComponent<PCXRGrapInteractable>();
        return base.CanHover(interactable) && component.GetSocket().Equals(_typePCSocket);
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        PCXRGrapInteractable component = interactable.transform.GetComponent<PCXRGrapInteractable>();
        return base.CanSelect(interactable) && component.GetSocket().Equals(_typePCSocket);
    }
}
