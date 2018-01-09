using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private int speed = 10;
	private int jumpPower = 1250;
	private bool facingRight = true;
	public bool isGrounded;

	private float moveX;
	private float neutralPos = 0.0f;
	
	void Update () {
		Move();
		PlayerRaycast();
	}

	void Move() {
		// Player input.
		moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump") && isGrounded) {
			Jump();
		}

		// Animations.

		// Player direction.
		bool wrongDirection = (moveX < neutralPos && facingRight) || (moveX > neutralPos && !facingRight);
		if (wrongDirection) {
			FlipPlayer();
		}

		// Physics.
		gameObject.GetComponent<Rigidbody2D>().velocity = 
			new Vector2(moveX * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void Jump() {
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
		isGrounded = false;
	}

	void FlipPlayer() {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void PlayerRaycast() {

		// Bounce on enemies.
		RaycastHit2D hitDown = Physics2D.BoxCast(transform.position, new Vector2(1.0f, 0.3f), 0f, Vector2.down, 1.0f);
		if (hitDown.collider != null && hitDown.collider.tag == "Enemy") {
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
			hitDown.collider.gameObject.GetComponent<EnemyDeath>().Kill();
			GUIManager.instance.UpdateScore(100);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == "Ground" || collision.collider.tag == "Platform") {
			isGrounded = true;
		}

		if (collision.collider.tag == "Enemy" || collision.collider.tag == "Hazard") {
			GetComponent<PlayerDeath>().Kill();
		}
	}
}
