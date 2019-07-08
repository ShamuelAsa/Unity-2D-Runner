using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float Speed;

    public UserInterface UI_Script;
    public Player_Controls Player;
    public int Health;
    public int maxHealth;

    public bool isDead;
    private Rigidbody2D _rb;


    public TextMeshPro Counting;

	void Start ()
    {
        Health = maxHealth;
        _rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        Counting.text = "" + Health;
        if(isDead != true)
        {
            _rb.isKinematic = true;
            _rb.AddForce(new Vector2(-Speed * Time.time, 0), ForceMode2D.Impulse);
            transform.Translate(-Speed * Time.deltaTime, 0, 0);
        }
       
        if (Player.GameOver == true)
        {
            isDead = true;
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
                Player.Drones.Clear();
                UI_Script.score += 10;
                isDead = true;
                maxHealth += Random.Range(1, 10);
                Health = maxHealth;
                StartCoroutine(DelayLife());

            }
        }
    }
    IEnumerator DelayLife()
    {
        GameObject[] Targets = GameObject.FindGameObjectsWithTag("Target");
        GameObject randomTarget = Targets[Random.Range(1, Targets.Length)];
        gameObject.transform.position = randomTarget.transform.position;
        yield return new WaitForSeconds(Random.Range(1.0f, 5.0f));

        isDead = false;
        if (UI_Script.score >= 100 && UI_Script.score <= 250)
        {
            Speed += 0.3f;
        }
        else
        Speed += Random.Range(0.1f, 0.3f);
    }
}
