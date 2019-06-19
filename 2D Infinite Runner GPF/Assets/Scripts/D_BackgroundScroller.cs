using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_BackgroundScroller : MonoBehaviour
{
    private Rigidbody2D r_scroll;
    private float speed = -1.5f;
    private bool gameOver = false;
	// Use this for initialization
	void Start ()
    {
        r_scroll = GetComponent<Rigidbody2D>();


        r_scroll.velocity = new Vector2(speed, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(gameOver == true)
        {
            r_scroll.velocity = Vector2.zero;
        }
    }
}
