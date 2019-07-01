using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    public float distance = 0.0f;
    public bool GameOver = false;
    public Animator attack;
    public List<GameObject> Drones = new List<GameObject>();
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
        GameObject enemyCollided = collision.gameObject;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyCollided.GetComponent<Enemy>().ReceiveDamage(1);
        }
    }
}