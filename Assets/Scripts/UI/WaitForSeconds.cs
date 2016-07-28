using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WaitForSeconds : MonoBehaviour {

    public float delay;

    void Start() {
        Invoke("LoadMenu", 4);
    }

    void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }
}
