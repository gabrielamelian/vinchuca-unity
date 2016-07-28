using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ApplicationData {
    static public Score lastScore = new Score();
}

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    private int score = 0;

    public void AddScore (int pointsWon) {
        score += pointsWon;
        scoreText.text = score.ToString();
    }

    public int GetScore() {
        return this.score;
    }
    
}

public class Score {
    public string name = "";
    public int score = 0;
    public bool saved = false;
}