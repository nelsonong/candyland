using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		GUIManager.instance.End();
		SceneManager.LoadScene(0);
	}
}
