using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	void Start () {
        Invoke("LoadNext", 4);
	}

    void LoadNext() {
        int lastScore = ApplicationData.lastScore.score;
        if (HighScoreController.IsNewHighScore(lastScore)) {
            SceneManager.LoadScene("HighScoreInput");
        } else {
            SceneManager.LoadScene("Menu");
        }
        
        
    }

}
