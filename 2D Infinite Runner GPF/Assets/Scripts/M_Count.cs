using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Count : MonoBehaviour
{
    public int Score;
    float currentDistance;
    private Text Counter;
	void Start ()
    {
        Counter = GetComponent<Text>();
	}
	

	void Update ()
    {
        currentDistance = Score * Time.time;

        Counter.text = Mathf.Round(currentDistance) + " M";
	}
}
