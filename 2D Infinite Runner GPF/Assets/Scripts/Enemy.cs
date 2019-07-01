using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public Player_Controls Player;
    public int Health;
    public int maxHealth;
    public Transform Target;
    public bool isDead;
    private Rigidbody2D _rb;
	void Start ()
    {
        Health = maxHealth;
        _rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        if(isDead != true)
        {
            _rb.velocity = new Vector2(-Speed * Time.time, 0);
                //= new Vector2(-Speed * Time.time, 0);
        }
       
        if (Player.GameOver == true)
        {
            gameObject.SetActive(false);
        }
    }

    public void ReceiveDamage(int Damage)
    {
        if(Health > 0)
        {
            Health -= Damage;
            if(Health <= 0)
            {
                isDead = true;
                maxHealth += Random.Range(1, 10);
                Health = maxHealth;
                gameObject.transform.position = Target.position;
                StartCoroutine(DelayLife());

            }
        }
    }
    IEnumerator DelayLife()
    {
        yield return new WaitForSeconds(1.0f);
        isDead = false;
    }
}
