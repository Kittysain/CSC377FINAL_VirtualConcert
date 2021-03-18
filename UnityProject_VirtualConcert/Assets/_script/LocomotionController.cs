using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{

    public XRController leftTeleRay;

    public bool leftTeleEnabled { get; set; } = true;

    public InputHelpers.Button teleportActivationButton;
    public float activationThresHold = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (leftTeleRay)
            leftTeleRay.gameObject.SetActive(leftTeleEnabled && CheckIfActivated(leftTeleRay));
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThresHold);
        return isActivated;

    }
}
