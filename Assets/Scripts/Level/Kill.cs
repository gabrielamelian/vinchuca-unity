using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {
	
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
		source = Main.GetComponent<AudioSource> ();
	}

	void OnMouseDown() {
		scoreManager.AddScore (spawner.fleaScore);
		source.PlayOneShot (smashSound, 1F);
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
		Destroy(gameObject);
		spawner.FleaCounter--;
	}

}
