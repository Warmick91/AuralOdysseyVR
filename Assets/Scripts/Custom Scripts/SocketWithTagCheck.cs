using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketWithTagCheck : XRSocketInteractor
{
    public string targetTag = null;

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable) && MatchTag((XRBaseInteractable)interactable);
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && MatchTag((XRBaseInteractable)interactable);
    }

    public bool MatchTag(XRBaseInteractable interactable)
    {
        return interactable.CompareTag(targetTag);
    }

}
