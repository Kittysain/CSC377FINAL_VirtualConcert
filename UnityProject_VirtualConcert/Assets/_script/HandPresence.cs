using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristic;
    public List<GameObject> controllerPrefabs;
    public bool showController = false;
    public GameObject handModelPrefab;


    private InputDevice targetDevice;
    private GameObject spawnController;
    private GameObject spawnHandModel;

    public bool primaryButtonPressed;


    // Start is called before the first frame update
    void Start()
    {
        tryInitializeControllers();
    }

    void tryInitializeControllers()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristic, devices);
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                spawnController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Corresponding controller model not found, use default controller");
                spawnController = Instantiate(controllerPrefabs[0], transform);
            }
        }

        spawnHandModel = Instantiate(handModelPrefab, transform);
    }
    // Update is called once per frame
    void Update()
    {
        if(!targetDevice.isValid)
            tryInitializeControllers();
        else
        {
            if (showController)
            {
                spawnHandModel.SetActive(false);
                spawnController.SetActive(true);
            }
            else
            {
                spawnHandModel.SetActive(true);
                spawnController.SetActive(false);
            }
        }
    }
}
