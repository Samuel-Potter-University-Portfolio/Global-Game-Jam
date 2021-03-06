﻿using UnityEngine;
using System.Collections;

public class SideOnMovement : MonoBehaviour {

	private Rigidbody2D body;
	private RawPlayerController gamepad;
	public float speed;
	public float jumpHeight;
	private bool onGround = false;

	void Start () {
		gamepad = GetComponent<RawPlayerController>();
		body = GetComponent<Rigidbody2D> ();
		body.gravityScale = 1;
		body.drag = 0.1f;
	}

	void FixedUpdate () {
		float y = body.velocity.y;

		if(onGround && gamepad.isPressingA())
		{
			y = jumpHeight;
			onGround = false;
		}


		Vector2 velocity = new Vector2 (gamepad.getHorizontalState() * speed, y);
		body.velocity = velocity;
	}

	void OnCollisionEnter2D(Collision2D collision){
		foreach(ContactPoint2D contact in collision.contacts){
			if(contact.normal.Equals(Vector2.up)){
				onGround = true;
			}
		}
	}

	void OnBecameInvisible(){
		GetComponent<RawPlayerController>().kill ();
	}
}
