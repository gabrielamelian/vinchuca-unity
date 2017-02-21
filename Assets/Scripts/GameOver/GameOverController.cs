using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    void Start() {
        Invoke("LoadNext", 4);
    }

    void LoadNext() {
        int lastScore = ApplicationData.lastScore.score;
        if(IsNewHighScore(lastScore)) {
            SceneManager.LoadScene("HighScoreInput");
        } else {
            SceneManager.LoadScene("Menu");
        }

    }

	public bool IsNewHighScore(int newScore) {
		List<Score> scores = ScoreManager.GetCurrentScores();
		foreach(Score s in scores) {
			if(newScore >= s.score) {
				return true;
			}
		}

		return false;
	}

}
