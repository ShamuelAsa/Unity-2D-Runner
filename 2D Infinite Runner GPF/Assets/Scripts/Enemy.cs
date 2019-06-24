using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public Player_Controls Player;
	void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Player.GameOver == false)
        {
            transform.position = new Vector2(-Speed * Time.time, 0);
        }
	}
}
