using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableFixedAttachTransform : XRGrabInteractable
{
    private bool isGrabbed = false;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        isGrabbed = false;
        base.OnSelectExited(args);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (isGrabbed && movementType == MovementType.Instantaneous)
        {
            var attachOffset = transform.position - attachTransform.position;
            transform.position = selectingInteractor.transform.position + attachOffset;
            transform.rotation = Quaternion.Inverse(Quaternion.Inverse(transform.rotation) * attachTransform.rotation * Quaternion.Inverse(selectingInteractor.transform.rotation));
        }
    }
}