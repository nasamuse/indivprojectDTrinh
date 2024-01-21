using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TImer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public static TImer instance;

    public AudioSource backgroundMusic;

    void awake()
    {
        instance = this;
    }

    public void updateCounter(float number)
    {
        if (number <= 10f)
        {
            timerText.text = "Time left: " + number.ToString("F");
            if (!backgroundMusic.isPlaying)
            {
                backgroundMusic.Play();
            }
        }
        else
        {
            timerText.text = "Time left: 10";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        instance = this;
    }
}
