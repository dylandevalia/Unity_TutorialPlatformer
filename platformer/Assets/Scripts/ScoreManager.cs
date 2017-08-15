using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;
	private static Text scoreText;

	private void Start() {
		score = 0;
		scoreText = GetComponent<Text>();
	}

	private static void updateScore() {
		if (score < 0) {
			score = 0;
		}

		scoreText.text = "" + score;
	}

	public static void addScore(int value) {
		score += value;
		updateScore();
	}
}
