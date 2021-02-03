using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "ThirdPersonPlayer")
        {
            Debug.Log("Hit the Cylinder");
            

        }
    }
}
