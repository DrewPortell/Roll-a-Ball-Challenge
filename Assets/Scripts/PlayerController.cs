using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //text variables 
    private const string GTag = "Pick Up";
    private const string ETag = "Enemy";
    public Text countText;
    public Text scoreText;
    public Text gameStatus;
    public Text livesText;
    public float speed;

    private Rigidbody rb;
    //game tracker variables 
    private int count;
    private int friend;
    private int lvl1prog;
    private int score;
    private int lives;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        friend = 0;
        score = 0;
        lives = 3;
        lvl1prog = 0;
        SetAllText();
        gameStatus.text = "";
        
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(GTag))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            friend = friend + 1; 
            score = score + 1;
            lvl1prog = lvl1prog + 1;
            SetAllText();
        }
        if(other.gameObject.CompareTag(ETag))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score - 1;
            lives = lives - 1;
            SetAllText();
        }
    }

    private void SetAllText()
    {
        countText.text = "Count: " + count.ToString();
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
        if(friend >= 16)
        {
            gameStatus.text = "You Win!";
        }
        if(lvl1prog == 8)
        {
            gameObject.transform.position = new Vector3(78.18f , 0 , 4.24f);
        }
        if(lives <= 0)
        {
            gameStatus.text = "You Lose...";
        }
    }
}
