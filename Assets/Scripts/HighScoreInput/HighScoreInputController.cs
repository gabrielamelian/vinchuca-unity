using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HighScoreInputController : MonoBehaviour {

    public InputField input;

    public void OnClick() {
        string name = input.text;
        if(name.Length != 0) {
            ApplicationData.lastScore.name = name;
            SceneManager.LoadScene("HighScore");
        }
    }

}
