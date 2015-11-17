using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	
	public Text scoreText;
	private int score = 0;

	public void AddScore (int pointsWon) {
		score += pointsWon;
		scoreText.text = score.ToString();
	}

}
