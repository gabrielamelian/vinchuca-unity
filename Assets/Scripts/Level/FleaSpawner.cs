using UnityEngine;
using System.Collections;

public class FleaSpawner : MonoBehaviour {

    public GameObject flea;
    [System.NonSerialized]
    public int FleaCounter = 0;
    [System.NonSerialized]
    public int fleaScore = 15;

	/// <summary>
	/// Initial values for variables.
	/// </summary>
    private int initialMaxFleas = 2;
    private float initialPercentageSpawn = 63f;
    private float initialTimeBetweenSpawns = 0.8f;
    
	/// <summary>
	/// Changing values that contain current difficulty settings
	/// </summary>
	private int maxFleas;
    private float percentageSpawn;
    private float timeBetweenSpawns;

	/// <summary>
	/// Time between difficulty changes.
	/// </summary>
    private float timeBetweenDifficulty = 10f;

	/// <summary>
	/// Upper limits of individual difficulty increases.
	/// </summary>
    private float maxPercentageSpawn = 80f;
    private float minTimeBetweenSpawns = 0.2f;

	/// <summary>
	/// Number of times we have increased difficulty.
	/// </summary>
    private int currentDiff = 0;

	/// <summary>
	/// Internal timers used by the scripts.
	/// </summary>
    private float spawnTimer;
    private float difficultyTimer;

    private GameObject main;
    private CatHealth catHealth;

    void Start() {
        maxFleas = initialMaxFleas;
        ResetSpawnRate();

        main = GameObject.FindGameObjectWithTag("Main");
        catHealth = main.GetComponent<CatHealth>();
    }

    void ResetSpawnRate() {
        percentageSpawn = initialPercentageSpawn;
        timeBetweenSpawns = initialTimeBetweenSpawns;
    }

    void FixedUpdate() {
        if(catHealth.currentHealth > 0) {
            Spawn();
            IncreaseDifficulty();
        }
    }

    void Spawn() {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= timeBetweenSpawns) {
            float random = Random.Range(0, 100);

            if(random < percentageSpawn) {
                int nb = Random.Range(1, maxFleas + 1);
                for(int i = 0; i < nb; i++) {
                    if(FleaCounter < maxFleas) {
                        Instantiate(flea, new Vector2(Random.Range(-5F, 5F), 0), Quaternion.identity);
                        FleaCounter++;
                    }
                }
            }

            spawnTimer = 0f;
        }
    }

    void IncreaseDifficulty() {
        difficultyTimer += Time.deltaTime;

        if(difficultyTimer > timeBetweenDifficulty) {
            bool increaseMaxFleas = currentDiff % 6 == 0 && currentDiff != 0;
            if(increaseMaxFleas) {
                maxFleas += 1;
                ResetSpawnRate();
            } else {
                float newPercentageSpawn = percentageSpawn + 0.25f;
                if(!(newPercentageSpawn > maxPercentageSpawn)) {
                    percentageSpawn = newPercentageSpawn;
                }

                float newTimeBetweenSpawns = timeBetweenSpawns - 0.05f;
                if(!(newTimeBetweenSpawns < minTimeBetweenSpawns)) {
                    timeBetweenSpawns -= 0.05f;
                }
            }

            currentDiff += 1;
            difficultyTimer = 0f;
        }
    }

}
