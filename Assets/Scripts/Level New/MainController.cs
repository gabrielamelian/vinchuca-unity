using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {


    public GameObject fleaObject;

    private float timer;

    void Start () {
        
	}
	
	void FixedUpdate () {
        timer += Time.deltaTime;
        bool spawnFlea = SpawnFlea(timer);
        if (spawnFlea) {
            Instantiate(fleaObject);
        }
    }

    bool SpawnFlea(float timer) {
        return true;
    }
}
