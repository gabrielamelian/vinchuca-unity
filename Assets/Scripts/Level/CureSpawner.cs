using UnityEngine;
using System.Collections;

public class CureSpawner : MonoBehaviour {

    public GameObject cure;
    
    private GameObject main;
    private CatHealth catHealth;
    private float spawnTimer;
    private float timeBetweenSpawns = 30f;

    void Start() {
        main = GameObject.FindGameObjectWithTag("Main");
        catHealth = main.GetComponent<CatHealth>();
    }

    void FixedUpdate() {
        Spawn();
    }

    void Spawn() {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= timeBetweenSpawns) {
            Instantiate(cure, new Vector2(Random.Range(-5F, 5F), 0), Quaternion.identity);
            spawnTimer = 0f;
        }
    }
}
