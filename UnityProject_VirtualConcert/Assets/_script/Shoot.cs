using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shoot : MonoBehaviour
{
    public float Velocity = 100.0f;
    public GameObject flower;
    public GameObject parentFlower;

    public void shoot()
    {
        //parentFlower.GetComponent<Rigidbody>().detectCollisions = false;

        Vector3 spawnPosition = parentFlower.transform.position + 5* parentFlower.transform.forward;
        GameObject spawnFlower = Instantiate(flower, spawnPosition, parentFlower.transform.rotation);
        
        if(flower == parentFlower)
        {
            spawnFlower.GetComponent<XRGrabInteractable>().enabled = false;
            spawnFlower.GetComponent<ModeSwitcher>().enabled = false;
            spawnFlower.GetComponent<BulletStay>().enabled = true;
            spawnFlower.GetComponent<ObjectHoldAndReturn>().enabled = false;
            spawnFlower.GetComponent<Rigidbody>().isKinematic = false;
            spawnFlower.GetComponent<Rigidbody>().useGravity = true;
        }
        Vector3 targetScale = spawnFlower.transform.localScale * 10;
        Vector3 forward = parentFlower.transform.forward;
        spawnFlower.GetComponent<Rigidbody>().velocity += forward * Velocity;
        spawnFlower.transform.localScale = Vector3.Lerp(spawnFlower.transform.localScale, targetScale, Time.deltaTime*20);
        Destroy(spawnFlower, 5.0f);
    }

    public void reEnableCollision()
    {
        parentFlower.GetComponent<Rigidbody>().detectCollisions = true;
    }
}

