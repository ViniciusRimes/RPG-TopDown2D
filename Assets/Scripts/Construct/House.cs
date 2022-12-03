using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private int woodAmount; //madeira necessária para construir uma casa
    [SerializeField] private float timeAmount; //contando tempo
    [SerializeField] private Color startColor; //cor da casa inicial e construcao
    [SerializeField] private Color endColor; //cor da casa depois de construida
    
    [Header("Components")]
    [SerializeField] private Transform point; //onde o player é colocado ao iniciar a animacao
    [SerializeField] private SpriteRenderer spriteHouse; //sprite da casa
    [SerializeField] private GameObject houseColl; //colisao da casa
 

   
    private PlayerAnim playerAnim;
    private PlayerItems playerItems;
    private Player player;
    private bool detectingPlayer;
    private float timeCount; //tempo necessário para a construcao
    private bool isBegining; //se a construcao ja comecou




    void Start()
    {
        playerAnim = FindObjectOfType<PlayerAnim>();
        player = playerAnim.GetComponent<Player>();
        playerItems = FindObjectOfType<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerItems.totalWood >= woodAmount)
        {
            //construcao é inicializada
            player.isPaused = true;
            isBegining = true;
            playerAnim.OnHammeringStarted();
            spriteHouse.color = startColor;
            player.transform.position = point.position;
            playerItems.totalWood -= woodAmount;
        } 
              
        
        if(isBegining)
        {
        timeCount += Time.deltaTime;

        if(timeCount >= timeAmount)
        {
            //casa é construida
            playerAnim.OnHammeringEnded();
            spriteHouse.color = endColor;
            player.isPaused = false;
            houseColl.SetActive(true);
        }
        
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        detectingPlayer = false;
    }
    
    }

