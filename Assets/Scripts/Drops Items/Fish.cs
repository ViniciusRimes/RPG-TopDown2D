using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private PlayerItems playerItems;
    
    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(playerItems.totalfishes < playerItems.fishesLimit)
            {
                playerItems.totalfishes++;
                Destroy(gameObject);
            }
        }
    }

}
