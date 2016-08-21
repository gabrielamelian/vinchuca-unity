using UnityEngine;
using System.Collections;

public class Heal : MonoBehaviour {

    public float healAmount = 30f;

    private GameObject main;
    private CatHealth catHealth;
    
    void Start() {
        main = GameObject.FindGameObjectWithTag("Main");
        catHealth = main.GetComponent<CatHealth>();
    }

    void OnMouseDown() {
        catHealth.ReceiveHeal(healAmount);
        DestroyCure();
    }

    void Update() {
        if(gameObject.transform.position.y < -1f) {
            DestroyCure();
        }
    }

    void DestroyCure() {
        Destroy(gameObject);
    }

}
