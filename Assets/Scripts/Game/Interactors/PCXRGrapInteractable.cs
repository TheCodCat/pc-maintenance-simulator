using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PCXRGrapInteractable : XRGrabInteractable
{
    [SerializeField] private TypePCSocket _socket;

    public TypePCSocket GetSocket()
    {
        return _socket;
    }
}
