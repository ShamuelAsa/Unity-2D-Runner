using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Controls : MonoBehaviour
{
    public float distance = 0.0f;
    public bool GameOver = false;
    public Animator attack;
    public List<GameObject> Drones = new List<GameObject>();
    public float curDistance;
    GameObject closest = null;

    float Timer = 10;
    bool useAbility = false;

    public Text cdText;
    void Update ()
    {
        if(!useAbility)
        {
            cdText.text = "Cooldown: " + Mathf.Round(Timer);
            Timer -= Time.deltaTime;
        }
        if(Timer <= 0)
        {
            useAbility = true;
            cdText.text = "C to use Ability!";
            Timer = 0;
        }

        ClosestEnemy();
        if (Input.GetKeyDown(KeyCode.Z) && distance < 60.0f)
        {
            StartCoroutine(Attack());

            closest.GetComponent<Enemy>().ReceiveDamage(1);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Attack());
        }

        if (Input.GetKeyDown(KeyCode.X) && distance < 60.0f)
        {
            StartCoroutine(Attack2());

            closest.GetComponent<Enemy>().ReceiveDamage(1);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(Attack2());
        }

        if (Input.GetKeyDown(KeyCode.C) && distance < 60.0f && Timer <= 0)
        {
            useAbility = false;
            Timer = 10;
            StartCoroutine(Deflect());
            closest.GetComponent<Enemy>().ReceiveDamage(10);
        }
        else if (Input.GetKeyDown(KeyCode.C) && Timer <= 0)
        {
            useAbility = false;
            Timer = 10;
            StartCoroutine(Deflect());
        }
    }
    IEnumerator Attack()
    {
        //Attack animation
        attack.SetTrigger("isAttacking");
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator Attack2()
    {
        //Attack animation
        attack.SetTrigger("isAttacking2");
        yield return new WaitForSeconds(0.1f);
    }


    IEnumerator Deflect()
    {
        attack.SetTrigger("isDeflecting");
        yield return new WaitForSeconds(0.1f);
    }
    public GameObject ClosestEnemy()
    {
        GameObject[] _enemies;
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        distance = Mathf.Infinity;
        Vector3 pos = transform.position;
        foreach (GameObject enemy in _enemies)
        {
            Vector3 diff = enemy.transform.position - pos;
            curDistance = diff.sqrMagnitude;
            if(curDistance < distance)
            {
                closest = enemy;
                distance = curDistance;  
            }
            else if(closest.GetComponent<Enemy>().Health <= 0)
            {
                closest = enemy;
            }
        }
        return closest;
    }
}