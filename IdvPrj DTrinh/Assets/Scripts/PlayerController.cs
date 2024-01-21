using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip WinSFX;
    public AudioClip LoseSFX;
    public int numCoins = 0;
    bool allCoinscollected = false;
    public TextMeshProUGUI gameOverText;
    bool gameOver = false;
    public float speed = 5.0f;
    public float timerCount = 12;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Jump");

        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal* Time.deltaTime;
        position.y = position.y + speed * jump * Time.deltaTime;
        transform.position = position;

        if (Input.GetKey(KeyCode.R))
        {
            if (gameOver == true)
            {
                timerCount = 10;
                SceneManager.LoadScene("Gameplay Scene"); // this loads the currently active scene
            }
        }

        if(timerCount > 0 && gameOver == false)
        {
            if(timerCount > 10f)
            {
                speed = 0;
            } else
            {
                speed = 5f;
            }

            TImer.instance.updateCounter(timerCount);
            timerCount -= Time.deltaTime;
        }

        if (timerCount <= 0 && gameOver == false)
        {
            LoseScreen();
        }
    }

    public void CheckWin(int scoreAmount)
    {
        numCoins = scoreAmount;

        // UIRobotCounter.instance.updateCounter(numFixedRobots);
        if (numCoins == 5 && gameOver == false)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        //call win screen method
       // PlaySound(winSFX);
        WinScreen();
    }

    public void WinScreen()
    {
        PlaySound(WinSFX);
        gameOverText.text = "You won! Press R to restart.";
        gameOver = true;
    }

    public void LoseScreen()
    {
        gameOverText.text = "You lost! Press R to restart";
        PlaySound(LoseSFX);
        speed = 0;
        gameOver = true;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
