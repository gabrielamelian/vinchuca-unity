using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	private Rigidbody rb;

	private float impulseX = Random.Range(-3f, 3f);
	private float impulseY = Random.Range(5f, 10f);

	void Start () {
		float torqueX = Random.Range(-200f, 200f);
		float torqueY = Random.Range(-200f, 200f);
	
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (new Vector3 (impulseX, impulseY), ForceMode.Impulse);
		rb.AddTorque (torqueX, torqueY, 0);
	}

}