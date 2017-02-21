using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class HighScoreInputController : MonoBehaviour {

    public InputField input;
	private int MAX_SCORES = 5;

    public void SubmitName() {
        string name = input.text;
        if(name.Length != 0) {
            ApplicationData.lastScore.name = name;

			WriteHighScore(ApplicationData.lastScore);
            ApplicationData.lastScore = new Score();
            
            SceneManager.LoadScene("HighScore");
        }
    }

	void WriteHighScore(Score scoreToWrite) {
		bool alreadyInserted = false;
		List<Score> scores = ScoreManager.GetCurrentScores();
		List<Score> newScores = new List<Score>();
		foreach(Score s in scores) {
			if(newScores.Count == MAX_SCORES) {
				break;
			}

			if(scoreToWrite.score >= s.score && !alreadyInserted) {
				newScores.Add(scoreToWrite);
				newScores.Add(s);
				alreadyInserted = true;
			} else {
				newScores.Add(s);
			}
		}

		ScoreManager.WriteHighScoresToFile(newScores);
	}
}
