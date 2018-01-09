using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {

	private float timeLeft = 120;
	private int playerScore = 0;
	private GameObject timeText;
	private GameObject scoreText;
	public static GUIManager instance;

	// Use this for initialization
	void Start () {
		instance = this;
		timeText = GameObject.FindGameObjectWithTag("Time");
		scoreText = GameObject.FindGameObjectWithTag("Score");
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		timeText.GetComponent<Text>().text = Mathf.Ceil(timeLeft).ToString();
		if (timeLeft <= 0.0f) {
			SceneManager.LoadScene("Level1");
		}
	}

	public void UpdateScore(int points) {
		playerScore += points;
		scoreText.GetComponent<Text>().text = "Score: " + playerScore.ToString();
	}

	public void End() {
		playerScore += (int)(timeLeft * 10);
		UpdateLeaderboard();
		SceneManager.LoadScene(0);
	}

	public void UpdateLeaderboard()
	{
		float[] leaderboard = new float[3];
		for (int i = 0; i < 3; i++) {
			leaderboard [i] = PlayerPrefs.GetFloat(i.ToString(), i * 20 + 40);
		}

		// Insert new score into leaderboard.
		for (int i = 0; i < leaderboard.Length; i++) {
			if (playerScore > leaderboard [i]) {
				for (int j = leaderboard.Length - 1; j > i; j--) {
					leaderboard[j] = leaderboard[j - 1];
				}
				leaderboard [i] = playerScore;
				SaveLeaderboard (leaderboard);
				break;
			}
		}
	}

	public void SaveLeaderboard(float[] leaderboard)
	{
		for (int i = 0; i < leaderboard.Length; i++) {
			PlayerPrefs.SetFloat (i.ToString(), leaderboard[i]);
		}
		SceneManager.LoadScene(0);
	}
}
