using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	private int score = 0;
	public int maxHiScoreEntries;

	public List<Score> scores = new List<Score>();

	public void AddScore (int pointsWon) {
		score += pointsWon;
		scoreText.text = score.ToString();
	}
	
	void Start () {

		string path = Application.persistentDataPath + "/HighScores.txt";
		string[] lines = System.IO.File.ReadAllLines (path);

		//Read all the lines and add them as objects to 'score' list
		foreach (string line in lines) {
			string[] splat = line.Split (',');
			var lineScore = new Score ();
			lineScore.name = splat [1];
			lineScore.score = int.Parse (splat [0]);

			scores.Add (lineScore);
			//Debug.Log(lineScore.name + " " + lineScore.score);
		}

		//Sort the list
		scores.Sort (delegate(Score x, Score y) {
			return y.score.CompareTo (x.score);
		});

		foreach (Score currentScore in scores)		
		{
			Debug.Log(currentScore.name + " " + currentScore.score);
		}

	}

	public void WriteHighScore() {

		if (score > scores [scores.Count - 1].score)
		{
			Score newHighScore = new Score ();
			newHighScore.name = "Alturil";
			newHighScore.score = score;
			scores.Add (newHighScore);

			scores.Sort (delegate(Score x, Score y) {
				return y.score.CompareTo (x.score);
			});

			if (scores.Count > maxHiScoreEntries)
			{
				scores.RemoveAt (scores.Count -1);
			}
		}
		
		string highScoresString = "";
		
		foreach (Score scoreLine in scores) {
			highScoresString += scoreLine.score + "," + scoreLine.name + "\r\n";
		}
		
		File.WriteAllText(Application.persistentDataPath +  "/HighScores.txt", highScoresString);
	}
	
}

public class Score {
	public string name { get; set;}
	public int score { get; set;}
}