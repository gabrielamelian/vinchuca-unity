using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public AudioClip JumpSound1;
	public AudioClip JumpSound2;
	public AudioClip JumpSound3;
	private AudioSource source;

	private Rigidbody rb;

	void Awake () {
		source = GetComponent<AudioSource> ();
	}

	void Start () {
		float impulseX = Random.Range(-3f, 3f);
		float impulseY = Random.Range(5f, 10f);
//		float torqueX = Random.Range(-200f, 200f);
//		float torqueY = Random.Range(-200f, 200f);
	
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (new Vector3 (impulseX, impulseY), ForceMode.Impulse);
		//rb.AddTorque (0, torqueY, 0);
		
		if (impulseX > 0f) {
			rb.rotation = Quaternion.Euler(0f, 180f, 0f);
		}

		PlayJumpSound ( Random.Range(1, 4));

	}

	void PlayJumpSound(int SoundId) {	
		switch (SoundId)
		{
		case 1:
			source.PlayOneShot (JumpSound1);
			break;
		case 2:
			source.PlayOneShot (JumpSound2);
			break;
		case 3:
			source.PlayOneShot (JumpSound3);
			break;
		}
	}

}