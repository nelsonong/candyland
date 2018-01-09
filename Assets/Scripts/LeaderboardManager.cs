using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour {

	public float[] leaderboard;

	void Awake () 
    {
		LoadLeaderboard();
    }

	public void LoadLeaderboard()
	{
		if (leaderboard.Length < 3) {
			leaderboard = new float[3];
			for (int i = 0; i < 3; i++) {
				leaderboard [i] = PlayerPrefs.GetFloat (i.ToString (), i * 20 + 40);
			}
		}

		Text[] entries = gameObject.GetComponentsInChildren<Text>();

		int j = 0;
		for (int i = 0; i < entries.Length; i++)
		{
			if (entries [i].tag != "Entry")
				continue;
			entries [i].text = leaderboard[j++].ToString ();
		}
	}
}