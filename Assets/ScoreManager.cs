using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	private int score = 0;

	public List<Score> scores = new List<Score>();

	public void AddScore (int pointsWon) {
		score += pointsWon;
		scoreText.text = score.ToString();
	}

	public void WriteHighScore() {

		Score newHighScore = new Score ();
		newHighScore.name = "Alturil";
		newHighScore.score = score;

		scores.Add (newHighScore);

		string highScoresString = "";

		foreach (Score scoreLine in scores) {
			highScoresString += scoreLine.score + "," + scoreLine.name + "\r\n";
		}

		File.WriteAllText(Application.persistentDataPath +  "/HighScores.txt", highScoresString);
	}

	void Start () {

		string path = Application.persistentDataPath + "/HighScores.txt";
		string[] lines = System.IO.File.ReadAllLines(path);

		foreach (string line in lines)
		{
			string[] splat = line.Split(',');
			var lineScore = new Score();
			lineScore.name = splat[1];
			lineScore.score = int.Parse(splat[0]);

			scores.Add(lineScore);

			Debug.Log(lineScore.name + " " + lineScore.score);

		}

	}
	
}

public class Score {
	public string name { get; set;}
	public int score { get; set;}
}