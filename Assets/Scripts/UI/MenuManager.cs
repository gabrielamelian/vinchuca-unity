using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public void LoadLevel(string levelName) {
        SceneManager.LoadScene(levelName);
    }

	public void ExitApplication() {
		Debug.Log ("Exiting Application");
		Application.Quit ();
	}

}
