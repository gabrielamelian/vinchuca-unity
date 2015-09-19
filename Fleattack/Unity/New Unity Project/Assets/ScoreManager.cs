using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public int Score;

	// Use this for initialization
	void Start () {
		Score = 0;	
	}
	
	// Update is called once per frame
	public void AddScore (int ScoreValue) {
		Score += ScoreValue;
		Debug.Log ("Score: " + Score);
	}
}
