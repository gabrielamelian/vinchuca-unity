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

    public void ReceiveDamage(int damage) {
        currentHealth -= damage;
        healthFill.fillAmount = currentHealth / maxHealth;

        if(currentHealth <= 0) {
            KillCat();
        }
    }

    void KillCat() {
        Score score = new Score();
        score.score = scoreManager.GetScore();
        ApplicationData.lastScore = score;

        SceneManager.LoadScene("GameOver");
    }
}