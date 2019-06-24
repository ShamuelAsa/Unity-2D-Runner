using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Count : MonoBehaviour
{
    public Player_Controls Player;
    public int Score;
    float currentDistance;
    private Text Counter;
	void Start ()
    {
        Counter = GetComponent<Text>();
	}
	

	void Update ()
    {
        if(Player.GameOver == false)
        {
            currentDistance = Score * Time.time;

            Counter.text = Mathf.Round(currentDistance) + " M";
        }

        else if(Player.GameOver == true)
        {
            Counter.text = Mathf.Round(currentDistance) + " M";
        }
	}
}
