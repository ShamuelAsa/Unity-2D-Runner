using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;

    private Rigidbody2D myRigidBody;

	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
		
	}
	

	void Update () {
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
	}
}
