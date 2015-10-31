using UnityEngine;
using System.Collections;

public class WaitForSeconds : MonoBehaviour {

	public float delay;

	void Start() {
		Invoke ("LoadMenu", 4);
	}

	void LoadMenu() {
		Application.LoadLevel("Menu");
	}
}
