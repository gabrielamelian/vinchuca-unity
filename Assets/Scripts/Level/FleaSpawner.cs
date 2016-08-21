using UnityEngine;
using System.Collections;

public class FleaSpawner : MonoBehaviour {

    public GameObject flea;
    [System.NonSerialized]
    public int FleaCounter = 0;
    [System.NonSerialized]
    public int fleaScore = 15;

    private int initialMaxFleas = 1;
    private float initialPercentageSpawn = 60f;
    private float initialTimeBetweenSpawns = 0.8f;
    private int maxFleas;
    private float percentageSpawn;
    private float timeBetweenSpawns;

    private float timeBetweenDifficulty = 10f;
    private float maxPercentageSpawn = 80f;
    private float minTimeBetweenSpawns = 0.2f;

    private int currentDiff = 0;

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
