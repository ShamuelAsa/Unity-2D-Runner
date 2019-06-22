using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflect : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Deflect Animation playing");
        }
    }

    void OnTriggerEnter2D (Collider other)
    {
        if(other.gameObject.tag == "Robot" || other.gameObject.tag == "Laser")
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Deflected!");
            }
        }
    }
}
