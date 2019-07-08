using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Player_Controls : MonoBehaviour
{
    public float distance = 0.0f;
    public bool GameOver = false;
    public Animator attack;
    public List<GameObject> Drones = new List<GameObject>();
    public float curDistance;
    GameObject closest = null;
    void Update ()
    {
        ClosestEnemy();

        if (Input.GetKeyDown(KeyCode.Z) && distance < 50.0f)
        {
            StartCoroutine(Attack());

            Debug.Log("Hit!");
            closest.GetComponent<Enemy>().ReceiveDamage(1);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Attack());
        } 
    }
    IEnumerator Attack()
    {
        //Attack animation
        attack.SetTrigger("isAttacking");
        Debug.Log("Attack!");
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