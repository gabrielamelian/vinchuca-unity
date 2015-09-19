using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public void LoadLevel (string levelName) {
		Application.LoadLevel(levelName);
	}
	
}
