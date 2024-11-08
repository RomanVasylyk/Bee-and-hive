using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingerColntroller : MonoBehaviour
{
    public int power;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) { 
    if (other.gameObject.tag == "Border") {
    Destroy(this.gameObject,0f);
    }
    }
    

}
