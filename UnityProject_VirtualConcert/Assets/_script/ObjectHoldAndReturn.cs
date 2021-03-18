using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHoldAndReturn : MonoBehaviour
{
    private Vector3 origLocation;
    private Quaternion origRotation;
    private Vector3 origScale;
    public bool isHold = false;
    // Start is called before the first frame update
    void Start()
    {
        origLocation = this.transform.position;
        origRotation = this.transform.rotation;
        origScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHold)
        {
            returnToOrig();
        }
    }

    public void setHoldtoTrue()
    {
        isHold = true;
    }

    public void setHoldtoFalse()
    {
        isHold = false;
    }

    private void returnToOrig()
    {
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        this.transform.position = Vector3.Lerp(this.transform.position, origLocation, Time.deltaTime * 10);
        this.transform.rotation = origRotation;
        this.transform.localScale = origScale;
    }
}
