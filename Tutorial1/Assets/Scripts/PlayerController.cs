using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   public float speed;
    public Text countText;
    public Text winText;
   private Rigidbody2D rb2d;
   private int count;
    public Text livesText;
    private int lives;

   void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = "";
        SetCountText();
        SetLivesText();
    }
   void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();

    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }
        if (count == 12) 
        {
            transform.position = new Vector2(43.0f, 43.0f); 
        }
    }
  
    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 24)
        {
            winText.text = "You win! Game created by Emily Rogers!";
        }
    }
    void SetLivesText()
    {
        livesText.text = "Lives:" + lives.ToString();
        if (lives < 1)
        {
            Destroy(gameObject);
            winText.text = "You Lose! Game created by Emily Rogers";
        }
    }
}
