using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    
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
 
    private PlayerItems playerItems;
    
    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
    }
    private void Start()
    {
        initialDigAmount = digAmount;
        
    }

    private void Update()
    {
        if(dugHole)
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }
        
            if(currentWater >= waterAmount)
            {
                spriterenderer.sprite = carrot; //encheu total de agua;
            

                if(Input.GetKeyDown(KeyCode.E))
                {
                    spriterenderer.sprite = null;
                    playerItems.totalCarrot += 1;
                    currentWater = 0;
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
