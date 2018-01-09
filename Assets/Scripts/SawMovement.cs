using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour {

	private float speed = 2.0f;
	private int xDirection = 1;
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody2D>().velocity
			= new Vector2(xDirection * -1, 0) * speed;

		transform.Rotate (Vector3.back * -90 * xDirection);
	}

	void FlipEnemy() {
		xDirection *= -1;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == "Platform") {
			FlipEnemy();
		}
	}
}
