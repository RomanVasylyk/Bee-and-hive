using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class pleyer : MonoBehaviour
{
    public float minDistance = 2f;
    public float smoothTime = 0.3f;
    public float maxMoveSpeed = 10f;
    Vector2 currentVelocity;
    public GameObject StingerPrefab;
    public float stingerSpeed = 20f;
    public TMP_Text scoreText;
    private int score = 0;
    private int stingerType = 0; 
    public GameObject[] stingerPrefabs;
    public Image stingerImage1, stingerImage2, stingerImage3;
    public GameObject btnLock1, btnLock2;
    private float timer = 0f;
    public TMP_Text timerText;



    void Start()
    {
        setStingerType(0); 
    }

    void Update() {
        timer += Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("F1");
        
    if (Input.GetMouseButton(0)) {
    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector2 newPosition = mousePosition + 
          ((Vector2)transform.position - mousePosition).normalized * minDistance;
    transform.position = Vector2.SmoothDamp(transform.position, 
                   newPosition, ref currentVelocity, smoothTime, maxMoveSpeed);
    Vector2 direction = mousePosition - (Vector2)transform.position;
    float alfa = Vector2.SignedAngle(Vector2.up, direction);
    transform.eulerAngles = new Vector3(0,0,alfa);
    }
    if (Input.GetKeyUp(KeyCode.Space)) {
    GameObject st1 = 
        Instantiate(stingerPrefabs[stingerType], transform.position, transform.rotation);
    Rigidbody2D rb = st1.GetComponent<Rigidbody2D>();
    rb.AddForce(transform.up * stingerSpeed, ForceMode2D.Impulse);
    Destroy(st1, 5f);
 }        



    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "coin") {
            score++;
            Destroy(other.gameObject);
            scoreText.text = "score: " + score;
        }
    }
public void setStingerType(int _typ) {
        stingerType = _typ;
        stingerType = _typ;
        Color tmp = new Color(256,256,256,256); // defaultný vzhľad
        stingerImage1.color = tmp;
        stingerImage2.color = tmp;
        stingerImage3.color = tmp;
        tmp = new Color(256,0,0,256); // prefarbenie na červenú v RGBA
        if (_typ == 0) stingerImage1.color = tmp;
        if (_typ == 1) stingerImage2.color = tmp;
        if (_typ == 2) stingerImage3.color = tmp;
    }
public void unlockStinger(int _btnNo) {
        if (_btnNo == 1) {
            if (score >= 10) {
                score = score - 10;
                btnLock1.SetActive(false);
            }
        }
        if (_btnNo == 2) {
            if (score >= 20) {
                score = score - 20;
                btnLock2.SetActive(false);
            }
        }
    }

public int GetScore()
{
    return score;
}

public float GetTimer()
{
    return timer;
}



}
