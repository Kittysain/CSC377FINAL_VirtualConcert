using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

/*This is a script that changes the mode of object*/

/*Right Primary Button*/
//Click on right primary button changes the object 

/*Right Secondary Button*/
//if the object has only one material, then secondary 
//button changes the material


public class ModeSwitcher : MonoBehaviour
{
    public List<GameObject> ObjectModes;

    public bool SingleMatSource;
    
    public List<Material> materials;
    
    public List<XRController> controllers = null;
    public GameObject source;

    private int currentSystem = 0;
    private int currentMaterial = 0;
    private bool primaryButtonLock = false;
    private bool secondButtonLock = false;

    private bool isHold;


    //Use right hand joystick to swich the mode of the object

    // Start is called before the first frame update
    void Start()
    {
        disableAllParticles();
        isHold = this.GetComponent<ObjectHoldAndReturn>().isHold;
        ifHold();
    }

    // Update is called once per frame
    void Update()
    {
        isHold = this.GetComponent<ObjectHoldAndReturn>().isHold;
        if (isHold)
        {
            CheckForInput();
        }
        else
        {
            ifNotHold();
        }
    }

    public void ifHold()
    {
        enableCurrentParticle();
    }

    public void ifNotHold()
    {
        disableAllParticles();
        currentSystem = 0;
        currentMaterial = 0;
        if (SingleMatSource)
            source.GetComponent<Renderer>().material = materials[0];
    }

    private void CheckForInput()
    {
        foreach (XRController controller in controllers)
        {
            if (controller.enableInputActions)
                CheckForButtonPress(controller.inputDevice);
        }

    }

    private void disableAllParticles()
    {
        foreach(GameObject system in ObjectModes)
        {
            system.SetActive(false);
        }
        //leaving the first one enabled
        ObjectModes[0].SetActive(true);
    }

    private void enableCurrentParticle()
    {
        ObjectModes[currentSystem].SetActive(true);
        if(SingleMatSource)
            ObjectModes[currentSystem].GetComponent<Renderer>().material = materials[currentMaterial];
    }

    private void CheckForButtonPress(InputDevice device)
    {

        device.TryGetFeatureValue(CommonUsages.primaryButton, out bool clicked);
        if (clicked != primaryButtonLock && clicked)
        {
            nextObject();
            if (SingleMatSource)
            {
                ObjectModes[currentSystem].GetComponent<Renderer>().material = materials[0];
                source.GetComponent<Renderer>().material = materials[0];
            }
            currentMaterial = 0;
            primaryButtonLock = clicked;
        }
        else if (clicked != primaryButtonLock && !clicked)
        {
            primaryButtonLock = clicked;
        }

        device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secClicked);
        if (secClicked != secondButtonLock && secClicked)
        {
            ObjectModes[currentSystem].SetActive(false);
            if(SingleMatSource)
                nextColor();
            ObjectModes[currentSystem].SetActive(true);
            secondButtonLock = secClicked;
        }
        else if (secClicked != secondButtonLock && !secClicked)
        {
            secondButtonLock = secClicked;
        }
    }

    private void nextObject()
    {
        ObjectModes[currentSystem].SetActive(false);
        if(currentSystem+1 >= ObjectModes.Count)
        {
            ObjectModes[0].gameObject.SetActive(true);
            currentSystem = 0;
            currentMaterial = 0;
        }
        else
        {
            ObjectModes[currentSystem + 1].gameObject.SetActive(true);
            currentSystem += 1;
            currentMaterial = 0;
        }
    }

    private void nextColor()
    {
        if(currentMaterial+1 >= materials.Count)
        {
            ObjectModes[currentSystem].GetComponent<Renderer>().material = materials[0];
            if(SingleMatSource)
                source.GetComponent<Renderer>().material = materials[0];
            currentMaterial = 0;
        }
        else
        {
            ObjectModes[currentSystem].GetComponent<Renderer>().material = materials[currentMaterial+1];
            if (SingleMatSource)
                source.GetComponent<Renderer>().material = materials[currentMaterial + 1];
            currentMaterial += 1;
        }
    }
    
}
