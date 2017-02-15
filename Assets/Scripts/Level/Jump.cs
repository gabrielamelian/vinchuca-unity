using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    public AudioClip JumpSound1;
    public AudioClip JumpSound2;
    public AudioClip JumpSound3;
	public Sprite fleaFalling;
    private AudioSource source;
	private SpriteRenderer fleaImage;

    private Rigidbody2D rb;

    void Awake() {
        source = GetComponent<AudioSource>();
    }

    void Start() {
		fleaImage = GetComponent<SpriteRenderer> ();

        float impulseX = Random.Range(-3f, 3f);
        float impulseY = Random.Range(7f, 10f);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(impulseX, impulseY), ForceMode2D.Impulse);

        PlayJumpSound(Random.Range(1, 4));

    }

	void FixedUpdate() {
		if (rb.velocity.y < 0) {
			fleaImage.sprite = fleaFalling;
		}
	}

    void PlayJumpSound(int SoundId) {
        switch(SoundId) {
            case 1:
                source.PlayOneShot(JumpSound1);
                break;
            case 2:
                source.PlayOneShot(JumpSound2);
                break;
            case 3:
                source.PlayOneShot(JumpSound3);
                break;
        }
    }

}