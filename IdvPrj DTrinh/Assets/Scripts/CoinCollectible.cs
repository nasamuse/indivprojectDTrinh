using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    private PlayerController Controller;
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            Destroy(gameObject);
            controller.PlaySound(collectedClip);
            controller.numCoins = controller.numCoins + 1;
            controller.CheckWin(controller.numCoins);
        }
        
    }
}
