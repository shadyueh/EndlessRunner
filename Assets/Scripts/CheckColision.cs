using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object entered the Trigger");
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Object is within the Trigger");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Object has exited the Trigger");
    }
}
