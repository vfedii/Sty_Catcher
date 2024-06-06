using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{

    public Rigidbody2D rb2D;
    public Vector2 JumpForce;

    public GameObject GameOverPanel; /*inter*/
    public TextMeshProUGUI PointsTextField;

    public AudioSource audioSource;

    public AudioClip hitSfx;
    public AudioClip jumpSfx;
    public AudioClip scoresSfx;

    public static bool GameOver; /*touch*/
    public static bool HasStarted;  /*touch*/

    public int Points;  /*inter*/

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;  /*touch*/
        HasStarted = false;  /*touch*/
    }

    // Update is called once per frame
    void Update()
    {
        PointsTextField.text = Points.ToString();

        if (GameOver)
            return;  /*touch*/

        if (Input.GetButtonDown("Jump")) 
        {
            audioSource.clip = jumpSfx;
            audioSource.Play();

            if (HasStarted == false)  /*touch*/
            {
                HasStarted = true;
                rb2D.gravityScale = 1;
            }

            rb2D.AddForce(JumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) /*touch*/
    {
        GameOver = true;
        GameOverPanel.SetActive(true); /*inter*/

        audioSource.clip = hitSfx;
        audioSource.Play();
    }


    private void OnTriggerEnter2D(Collider2D collision)  /*inter*/
    {
        Points++; /*inter*/

        audioSource.clip = scoresSfx;
        audioSource.Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene("FlappyBird");
    }
    
}
