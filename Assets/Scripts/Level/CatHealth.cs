using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatHealth : MonoBehaviour {

	public int maxHealth = 100;
	public Slider healthSlider;
	
	public Text gameOverText;
	public Image gameOverImage;
		
	private int currentHealth;
	
	void Start () {
		currentHealth = maxHealth;
	}

	public void ReceiveDamage(int damage) {
		currentHealth -= damage;
		healthSlider.value = currentHealth;

		if (currentHealth <= 0)
		{
			KillCat();
		}
	}

	void KillCat()
	{
		gameOverText.enabled = true;
		gameOverImage.enabled = true;
		Invoke ("LoadMenu", 4);
	}

	void LoadMenu() {
		Application.LoadLevel("Menu");
	}

}