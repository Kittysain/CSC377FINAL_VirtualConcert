using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStay : MonoBehaviour
{

    public GameObject Wall;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Wall)
        {
            Rigidbody thisBody = this.GetComponent<Rigidbody>();
            GameObject thisFlower = this.GetComponent<GameObject>();
            thisBody.velocity = Vector3.zero;
            thisBody.angularVelocity = Vector3.zero;
            thisBody.isKinematic = true;
            thisBody.useGravity = false;
            thisBody.detectCollisions = false;
        }
    }
}
