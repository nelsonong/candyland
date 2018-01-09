using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDeath : MonoBehaviour {

	void Update () {
		if (gameObject.transform.position.y < -7) {
			Destroy(gameObject);
		}
	}

	public void Kill() {
		GetComponent<BoxCollider2D>().enabled = false;
		GetComponent<Rigidbody2D>().AddForce(Vector2.right * 300);
		GetComponent<Rigidbody2D>().gravityScale = 15;
		GetComponent<Rigidbody2D>().freezeRotation = false;
	}
}
