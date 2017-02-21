using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;
using System;

public class HighScoreController : MonoBehaviour {

    public Text nameTextObject;
    public Text scoreTextObject;
    public static string STORE_FILENAME = "/HighScores.txt";

    private string scoreFilePath;
    private int MAX_SCORES = 5;

    void Start() {
        this.scoreFilePath = Application.persistentDataPath + STORE_FILENAME;
        if(!ApplicationData.lastScore.saved) {
            WriteHighScore(ApplicationData.lastScore);
            ApplicationData.lastScore.saved = true;
        }

        DisplayScores();
    }

    void DisplayScores() {
        List<Score> scores = GetCurrentScores();

        string nameString = "";
        string scoreString = "";
        foreach(Score s in scores) {
            nameString += s.name + System.Environment.NewLine;
            scoreString += s.score + System.Environment.NewLine;
        }

        nameTextObject.text = nameString;
        scoreTextObject.text = scoreString;
    }

    void WriteHighScore(Score scoreToWrite) {
        bool alreadyAppended = false;
        List<Score> scores = GetCurrentScores();
        List<Score> newScores = new List<Score>();
        foreach(Score s in scores) {
            if(newScores.Count == MAX_SCORES) {
                break;
            }

            if(scoreToWrite.score >= s.score && !alreadyAppended) {
                newScores.Add(scoreToWrite);
                newScores.Add(s);
                alreadyAppended = true;
            } else {
                newScores.Add(s);
            }
        }

        WriteHighScoresToFile(newScores);
    }

    void WriteHighScoresToFile(List<Score> scores) {
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

        File.WriteAllText(scoreFilePath, scoresStr);
    }

    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
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
            score.saved = true;
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

    public static string GetFilePath() {
        return Application.persistentDataPath + HighScoreController.STORE_FILENAME;
    }

    public static bool IsNewHighScore(int newScore) {
        List<Score> scores = GetCurrentScores();
        foreach(Score s in scores) {
            if(newScore >= s.score) {
                return true;
            }
        }

        return false;
    }

}
