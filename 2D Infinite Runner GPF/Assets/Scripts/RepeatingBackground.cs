using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D B_Collider;
    private float B_HorizontalLength;

	private void Awake ()
    {
        B_Collider = GetComponent<BoxCollider2D>();
        B_HorizontalLength = B_Collider.size.x;
	}
	

	private void Update ()
    {
        if (transform.position.x < -B_HorizontalLength)
        {
            RepositionBackground();
        }
	}

    private void RepositionBackground()
    {
        Vector2 offset = new Vector2 (B_HorizontalLength * 2f, 0);

        transform.position = (Vector2) transform.position + offset;
    }
}
