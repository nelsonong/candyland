﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		GUIManager.instance.UpdateScore(500);
		Destroy(gameObject);
	}
}
