using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {

	void OnMouseDown() {
		Destroy(gameObject);
	}

	void Update()
	{
		if (gameObject.transform.position.y < -1f) {
			//print(gameObject.transform.position.y);
			Destroy(gameObject);
		}
	}

}
