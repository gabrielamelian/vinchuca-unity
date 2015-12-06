using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatHealth : MonoBehaviour {

	public float maxHealth = 100f;
	public Slider healthSlider;
	public Image healthFill;

	public Text gameOverText;
	public Image gameOverImage;

	public float currentHealth;

	private ScoreManager scoreManager;

	void Start () {
		currentHealth = maxHealth;

		GameObject Main = GameObject.FindGameObjectWithTag ("Main");
		scoreManager = Main.GetComponent<ScoreManager> ();
	}

	public void ReceiveDamage(int damage) {
		currentHealth -= damage;
		healthFill.fillAmount = currentHealth / maxHealth;

		if (currentHealth <= 0)
		{
			KillCat();
		}
	}

	void KillCat()
	{
		gameOverText.enabled = true;
		gameOverImage.enabled = true;
		scoreManager.WriteHighScore ();
		//Invoke ("LoadMenu", 4);
	}

	void LoadMenu() {
		Application.LoadLevel("Menu");
	}

}