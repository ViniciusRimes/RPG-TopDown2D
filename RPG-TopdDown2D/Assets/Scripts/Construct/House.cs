using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private Transform point;
    [SerializeField] private float timeAmount;
    [SerializeField] private SpriteRenderer spriteHouse;
    [SerializeField] private GameObject houseColl;

   
    private PlayerAnim playerAnim;
    private Player player;
    private bool detectingPlayer;
    private float timeCount;
    private bool isBegining;



    void Start()
    {
        playerAnim = FindObjectOfType<PlayerAnim>();
        player = playerAnim.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            player.isPaused = true;
            isBegining = true;
            playerAnim.OnHammeringStarted();
            spriteHouse.color = startColor;
            player.transform.position = point.position;
            
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
