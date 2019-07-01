using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    public bool GameOver = false;
    public Animator attack;
    public Enemy _enemy;
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
        attack.SetTrigger("isAttacking");
        Debug.Log("Attack!");
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Collider2D>().isTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            _enemy.ReceiveDamage(1);
        }
    }
}