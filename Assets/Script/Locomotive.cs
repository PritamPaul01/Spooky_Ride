using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotive : MonoBehaviour
{
    public float speed;
    public GameObject destination;
    private Rigidbody rb;

    public GameObject trainSensor;

    GameObject nextDestination;

    public float turningSpeed=1f;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        nextDestination=trainSensor.GetComponent<DestinationSensor>().detectedDestination;
        Debug.Log(nextDestination);
        if(nextDestination)
        {
            Vector3 lookPos=nextDestination.transform.position-transform.position;
            lookPos.y=0;
            Quaternion rotation=Quaternion.LookRotation(lookPos);
            transform.rotation=Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime*turningSpeed);

            rb.velocity=transform.forward*speed;
        }
    }
}
