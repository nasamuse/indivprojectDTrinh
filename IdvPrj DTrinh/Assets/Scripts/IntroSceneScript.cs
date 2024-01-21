using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroSceneScript : MonoBehaviour
{
    private PlayerController Controller;
    public TextMeshProUGUI introText;
    public float introTimer = 2;
    void Update()
    {
        introText.text = "Collect all the coins. WASD to move, hold SPACE to jump";


        //Close intro tutorial text after 2 seconds
        if(introTimer <= 0)
        {
            introText.text = "";
            Controller.timerCount = 10;
        }
        if (introTimer > 0)
        {
            introTimer -= Time.deltaTime;
        }
    }

}
