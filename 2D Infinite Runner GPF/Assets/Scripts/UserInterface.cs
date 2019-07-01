using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = "Score: " + score;
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
