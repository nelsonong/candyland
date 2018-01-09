using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceMovement : MonoBehaviour {

	private float speed = 2.0f;
	private int xDirection = 1;
	private bool hitGround = false;
	
	void Update () {
		if (hitGround && transform.position.y < 5) {
			gameObject.GetComponent<Rigidbody2D>().velocity
				= new Vector2(0, 1) * speed;
		} else if (transform.position.y >= 5) {
			hitGround = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		StartCoroutine(Die());
	}

	IEnumerator Die() {
		yield return new WaitForSeconds(1.5f);
		hitGround = true;
	}
}
