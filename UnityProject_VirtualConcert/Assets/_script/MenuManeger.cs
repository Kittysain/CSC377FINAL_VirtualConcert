using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class MenuManeger : MonoBehaviour
{
    public Panel currentPenal = null;
    private List<Panel> panelHistory = new List<Panel>();
    public XRController rightController;
    public XRController leftController;

    private void Start()
    {
        SetUpPanels();
    }
    public void HideMenu()
    {
        this.GetComponent<Canvas>().enabled = false;
    }

    private void SetUpPanels()
    {
        Panel[] panels = GetComponentsInChildren<Panel>();

        foreach(Panel panel in panels)
        {
            panel.Setup(this);
        }

        currentPenal.show();
    }

    private void Update()
    {
        if (CheckSecondaryButtonPressend(rightController) || CheckSecondaryButtonPressend(leftController))
            GoToPrevious();
    }

    private bool CheckSecondaryButtonPressend(XRController controller)
    {
        InputHelpers.IsPressed(rightController.inputDevice, InputHelpers.Button.SecondaryButton, out bool isPressed);
        return isPressed;
    }

    public void GoToPrevious()
    {
        if (panelHistory.Count == 0)
            return;

        int lastIndex = panelHistory.Count - 1;
        SetCurrent(panelHistory[lastIndex]);
        panelHistory.RemoveAt(lastIndex);
    }

    public void SetCurrentWithHistory(Panel newPanel)
    {
        panelHistory.Add(currentPenal);
        SetCurrent(newPanel);
    }

    public void SetCurrent(Panel newPanel)
    {
        currentPenal.hide();
        currentPenal = newPanel;
        currentPenal.show();
    }
}

