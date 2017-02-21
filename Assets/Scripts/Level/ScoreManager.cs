using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.IO;

public class ApplicationData {
    static public Score lastScore = new Score();
}

public class ScoreManager : MonoBehaviour {

	public static string STORE_FILENAME = "/HighScores.txt";

    public void AddScore(int pointsWon) {
		ApplicationData.lastScore.score += pointsWon;
    }

	public static string GetFilePath() {
		return Application.persistentDataPath + ScoreManager.STORE_FILENAME;
	}

	public static List<Score> GetCurrentScores() {
		string scoreFilePath = GetFilePath();
		bool fileExists = File.Exists(scoreFilePath);
		if(fileExists) {
			return GetScoresFromFile();
		} else {
			return GetFakeScores();
		}
	}

	static List<Score> GetScoresFromFile() {
		List<Score> scores = new List<Score>();
		string[] lines = File.ReadAllLines(GetFilePath());
		foreach(string line in lines) {
			string[] splat = line.Split(',');

			Score score = new Score();
			score.name = splat[0];
			score.score = Int32.Parse(splat[1]);

			scores.Add(score);
		}

		return scores;
	}

	public static List<Score> GetFakeScores() {
		List<Score> scores = new List<Score>();

		scores.Add(new Score { name = "Wiki", score = 1000 });
		scores.Add(new Score { name = "Gaby", score = 750 });
		scores.Add(new Score { name = "Altu", score = 500 });
		scores.Add(new Score { name = "Peter", score = 137 });
		scores.Add(new Score { name = "Eze", score = 133 });

		return scores;
	}

	public static void WriteHighScoresToFile(List<Score> scores) {
		int i = 0;
		string scoresStr = "";
		int count = scores.Count;
		foreach(Score s in scores) {
			scoresStr += s.name + ",";
			scoresStr += s.score;

			if(i < count - 1) {
				scoresStr += System.Environment.NewLine;
			}

			i += 1;
		}

		File.WriteAllText(GetFilePath(), scoresStr);
	}
}

public class Score {
    public string name = "";
    public int score = 0;
}