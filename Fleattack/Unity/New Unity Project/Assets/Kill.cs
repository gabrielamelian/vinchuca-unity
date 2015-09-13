using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {

	private GameObject Main;
	private Spawner spawner;

	void Start () {
		Main = GameObject.FindGameObjectWithTag ("Main");
		spawner = Main.GetComponent<Spawner>();
	}

	void OnMouseDown() {
		KillFlea ();
	}

	void Update()
	{			
		if (gameObject.transform.position.y < -1f) {
			KillFlea();
		}
	}

	void KillFlea() {
		Destroy(gameObject);
		spawner.FleaCounter--;
	}
	
}
