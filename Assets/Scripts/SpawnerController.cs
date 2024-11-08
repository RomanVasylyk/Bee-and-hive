using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour { 
    public float myTime;
    public GameObject[] enemies;


    void Start() {
     myTime = 0;
    }
     void Update()  {
  myTime += Time.deltaTime;
  if (myTime > 1) {
    int randomValue = Random.Range(0, enemies.Length); // náhodné číslo 
    int minus = Random.Range(0, randomValue + 1); // pravdepodobnosť že bude 0 je malá
    int index = randomValue - minus; // rozdiel medzi náhodnými číslami
    Instantiate(enemies[index], transform.position, transform.rotation);
    myTime = 0;
 }        
}

}

