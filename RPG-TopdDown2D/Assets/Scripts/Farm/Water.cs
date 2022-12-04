using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    
    [SerializeField] private bool detectingPlayer; //se o player está na colisão
    [SerializeField] private int waterValue; //valor que enche a cada aperto no botao

    private Casting casting;

    private PlayerItems playeritems;
    private Player player;
    
    private void Awake()
    {
        playeritems = FindObjectOfType<PlayerItems>(); // procurando o objeto na cena
        casting = FindObjectOfType <Casting>();
        player = FindObjectOfType<Player>();
    }
    void Start()
    {

         
    }

    
    void Update()
    {
        if(detectingPlayer = true && Input.GetKeyDown(KeyCode.E) && !casting.isCasting && player.handlingObj == 2)
        {
       
            playeritems.WaterLimit(waterValue); //enchendo o regador
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         if(collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
