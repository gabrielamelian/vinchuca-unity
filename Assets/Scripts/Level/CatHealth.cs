using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CatHealth : MonoBehaviour {

    public float maxHealth = 100f;
    public Slider healthSlider;
    public Image healthFill;

    public float currentHealth;

    void Start() {
        currentHealth = maxHealth;
    }

    private void UpdateHealth(float newHealth) {
        currentHealth = newHealth;
        healthFill.fillAmount = currentHealth / maxHealth;
    }

    public void ReceiveDamage(int damage) {
        float newHealthAmount = currentHealth - damage;
        UpdateHealth(newHealthAmount);

        if(currentHealth <= 0) {
            KillCat();
        }
    }

    public void ReceiveHeal(float healAmount) {
        float newHealthAmount = currentHealth + healAmount;

        if(newHealthAmount > maxHealth) {
            UpdateHealth(maxHealth);
        } else {
            UpdateHealth(newHealthAmount);
        }

    }

    void KillCat() {
        SceneManager.LoadScene("GameOver");
    }
}