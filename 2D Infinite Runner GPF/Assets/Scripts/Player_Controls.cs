using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Controls : MonoBehaviour
{
    float distance = 0.0f;
    public bool GameOver = false;
    public Animator attack;
    
    float curDistance;
    GameObject closest = null;

    float Timer = 10;
    bool useAbility = false;

    int _comboC;
    public Text cdText;
    public Text comboText, comboN;

    private void Start()
    {
        _comboC = 0;
    }
    void Update ()
    {
        if(_comboC == 0)
        {
            comboText.text = "";
            comboN.text = "";
        }
        else if(_comboC >= 2)
        {
            comboText.text = "Combo";
            comboN.text = _comboC + "!";
        }
        if(!useAbility)
        {
            cdText.text = "Cooldown: " + Mathf.Round(Timer);
            Timer -= Time.deltaTime;
        }
        if(Timer <= 0)
        {
            useAbility = true;
            cdText.text = "Space to use Ability!";
            Timer = 0;
        }

        ClosestEnemy();
        if (Input.GetKeyDown(KeyCode.D) && distance < 70.0f)
        {
            StartCoroutine(Attack());
            _comboC += 1;

            closest.GetComponent<Enemy>().ReceiveDamage(1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(Attack());
            _comboC = 0;
        }

        if (Input.GetKeyDown(KeyCode.J) && distance < 70.0f)
        {
            StartCoroutine(Attack2());
            _comboC += 1;

            closest.GetComponent<Enemy>().ReceiveDamage(1);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(Attack2());
            _comboC = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && distance < 70.0f && Timer <= 0)
        {
            _comboC += 1;
            useAbility = false;
            Timer = 10;
            StartCoroutine(Deflect());
            closest.GetComponent<Enemy>().ReceiveDamage(10);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Timer <= 0)
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