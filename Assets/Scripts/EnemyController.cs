using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject target;
    public int health = 3;
    public float speed = 0.5f;
    public GameObject coin;

    void Start() {
    target = GameObject.FindWithTag("HiveCenter").gameObject;
    }

    void Update() {
    Vector3 direction = target.transform.position - transform.position;
    direction = direction.normalized;
    transform.position += direction * speed * Time.deltaTime;
    if (health <= 0) {
    Destroy(gameObject);
    } 
    }
    private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "stinger") {
       GameObject stinger = other.gameObject; // prístup k objektu kolízie – stinger
       // získanie skriptu cez jeho typ – trieda skriptu so skomoleným nazvom
       // získame komponent objektu other – ktorý spôsobil kolíziu, ktorý je daného typu
       StingerColntroller script = stinger.GetComponent<StingerColntroller>();
       // Skontrolovanie, či existuje skript, lebo nemusi byt na objekt pridany
       if (script != null) {
           // ak skript na objekte stinger existuje, precita sa nastavená hodnota power
           int power = script.power;
           health = health - power; // odpočíta sa hodnota sily stingeru 
       }
       Destroy(other.gameObject);
       Instantiate(coin, transform.position, transform.rotation);
    }
}



}
