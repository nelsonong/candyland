using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopsMovement : MonoBehaviour {

	private float speed = 1.2f;
	private int xDirection = 1;
	private bool hit = false;
	
	void Update () {
		if (!hit) {
			gameObject.GetComponent<Rigidbody2D>().velocity
				= new Vector2(xDirection, 0) * speed;
		}
	}

	void FlipEnemy() {
		xDirection *= -1;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag != "Player") {
			FlipEnemy();
		} else {
			hit = true;
		}
	}
}
