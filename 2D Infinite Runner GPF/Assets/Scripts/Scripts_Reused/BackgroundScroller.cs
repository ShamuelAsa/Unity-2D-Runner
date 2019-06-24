using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Player_Controls Player;

    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
        if(Player.GameOver == true)
        {
            speed = 0;
        }
    }
}

//Please do not remove this until I can confirm the usage of the other background scroller or deciding to use this as our last resort.

//Reason: Resolution change to a smaller resolution will cause the character to disappear. Otherwise, we stick to 16:9 ratio resolution and keep this script. 