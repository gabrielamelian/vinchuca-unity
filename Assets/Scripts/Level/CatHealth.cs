using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CatHealth : MonoBehaviour {

    public float maxHealth = 100f;
    public Slider healthSlider;
    public Image healthFill;

    public float currentHealth;

    private ScoreManager scoreManager;

    void Start() {
        currentHealth = maxHealth;

        GameObject Main = GameObject.FindGameObjectWithTag("Main");
        scoreManager = Main.GetComponent<ScoreManager>();
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
        Score score = new Score();
        score.score = scoreManager.GetScore();
        ApplicationData.lastScore = score;

        SceneManager.LoadScene("GameOver");
    }
}