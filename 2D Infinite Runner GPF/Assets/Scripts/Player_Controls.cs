using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Attack());
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Deflect Animation playing");
        }
    }
    IEnumerator Attack()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        Debug.Log("Attack!");
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        Debug.Log("Attack animation ended!");
    }
}
