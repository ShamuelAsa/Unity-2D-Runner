using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    private int Health = 1;
    private int Damage = 1;
    public bool GameOver = false;

	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        //Attack animation
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        Debug.Log("Attack!");
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        Debug.Log("Attack animation ended!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Laser")
        {
            Health -= Damage;
        }
    }
}