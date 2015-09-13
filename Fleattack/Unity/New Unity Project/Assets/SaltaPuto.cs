using UnityEngine;
using System.Collections;

public class SaltaPuto : MonoBehaviour {

	public float X;
	public float Y;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddForce(new Vector2(X, Y), ForceMode2D.Impulse);	
	}
	
	// Update is called once per frame
	void Update () {	

	}
}
