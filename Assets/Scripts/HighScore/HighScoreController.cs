using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class HighScoreController : MonoBehaviour {

    public Text nameTextObject;
    public Text scoreTextObject;

    private string scoreFilePath;

    void Start() {
        DisplayScores();
    }

    void DisplayScores() {
        List<Score> scores = ScoreManager.GetCurrentScores();

        string nameString = "";
        string scoreString = "";
        foreach(Score s in scores) {
            nameString += s.name + System.Environment.NewLine;
            scoreString += s.score + System.Environment.NewLine;
        }

        nameTextObject.text = nameString;
        scoreTextObject.text = scoreString;
    }


    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }

}
