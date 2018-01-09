using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

	private bool dead = false;
	
	void Update () {
		if (gameObject.transform.position.y < -7) {
			dead = true;
		}

		if (dead) {
			StartCoroutine(Die());
		}
	}

	IEnumerator Die() {
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene(0);
	}

	public void Kill() {
		GetComponent<CapsuleCollider2D>().enabled = false;
		GetComponent<Rigidbody2D>().AddForce(Vector2.left * 500);
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
		GetComponent<Rigidbody2D>().gravityScale = 15;
		GetComponent<Rigidbody2D>().freezeRotation = false;
	}
}
