using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class enableMenu : MonoBehaviour
{
    public XRController leftController;
    public GameObject menuHolder;
    public Canvas menu;
    private bool menuEnabled = true;
    private bool locked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        menuEnabled = menu.GetComponent<Canvas>().enabled;
        bool clicked = checkButtonPressed(leftController);
        if(clicked != locked && clicked)
        {
            menuHolder.transform.position = Camera.main.transform.position + 3 * Camera.main.transform.forward;
            menuHolder.transform.rotation = Camera.main.transform.rotation;

            menu.GetComponent<Canvas>().enabled = !menuEnabled;
            locked = clicked;
        }
        else if (clicked != locked && !clicked)
        {
            locked = clicked;
        }
    }

    private bool checkButtonPressed(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, InputHelpers.Button.PrimaryButton, out bool isPressed);
        return isPressed;
    }
}
