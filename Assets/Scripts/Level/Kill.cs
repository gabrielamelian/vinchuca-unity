using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {
	
	public int ScoreValue;
	public int FleaDamage;

	private GameObject Main;

	private Spawner spawner;
	private ScoreManager scoreManager;
	private CatHealth catHealth;

	public AudioClip smashSound;
	private AudioSource source;

	void Start () {
		Main = GameObject.FindGameObjectWithTag ("Main");
		
		spawner = Main.GetComponent<Spawner>();
		scoreManager = Main.GetComponent<ScoreManager> ();
		catHealth = Main.GetComponent<CatHealth> ();

		source = GetComponent<AudioSource> ();
	}

	void OnMouseDown() {
		scoreManager.AddScore (ScoreValue);
		KillFlea ();
	}

	void Update()
	{			
		if (gameObject.transform.position.y < -1f) {
			KillFlea();
			catHealth.ReceiveDamage(FleaDamage);
		}
	}

	void KillFlea() {
		source.PlayOneShot (smashSound, 1F);
		Destroy(gameObject);
		spawner.FleaCounter--;

	}
	
}
