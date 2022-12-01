using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
     [SerializeField] private AudioClip holeSFX;
     [SerializeField] private AudioClip carrotSFX;

    [Header("Components")]
    [SerializeField] private SpriteRenderer spriterenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    
     [Header("Settings")]
    [SerializeField] private int digAmount; //quantidade de vezes para escavar
    [SerializeField] private bool detecting;
    [SerializeField] private float waterAmount; //total de agua para nascer uma cenoura
    private int initialDigAmount;
    private float currentWater;
    private bool dugHole;
    private bool plantedCarrot;
 
    private PlayerItems playerItems;

    private void Start()
    {
        initialDigAmount = digAmount;
        playerItems = FindObjectOfType<PlayerItems>();
        
    }

    private void Update()
    {
        if(dugHole)
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }
        
            if(currentWater >= waterAmount && !plantedCarrot)
            {
                audioSource.PlayOneShot(holeSFX);
                spriterenderer.sprite = carrot; //encheu total de agua;
                plantedCarrot = true;

            }
            
            if(Input.GetKeyDown(KeyCode.E) && plantedCarrot)
            {
                if(playerItems.totalCarrot < playerItems.carrotLimit)
                {
                    audioSource.PlayOneShot(carrotSFX);
                    spriterenderer.sprite = null;
                    currentWater = 0f;
                    playerItems.totalCarrot += 1;
                    dugHole = false;
                    plantedCarrot = false;
                }
                    
            }
        }
        
       
    }
    

    public void OnHit()
    {
        digAmount--;

        if(digAmount == 0)
        {
            //escavando o buraco
            spriterenderer.sprite = hole;
            dugHole = true;
            digAmount = initialDigAmount;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dig"))
        {
            OnHit();
        }
        if(collision.CompareTag("Water"))
        {
            detecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Water"))
        {
            detecting = false;
        }
    }
}
