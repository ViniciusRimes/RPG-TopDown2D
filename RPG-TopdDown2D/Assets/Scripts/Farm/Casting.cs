using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
 {
    private bool detectingPlayer; //se o player está na colisão
    [SerializeField] private int percentage; //porcentagem de chance de pescar um peixe


    private PlayerItems player;
    private PlayerAnim playerAnim;
    
    private void Awake()
    {
        //player = FindObjectOfType<PlayerItems>(); // procurando o objeto na cena
        //playerAnim = FindObjectOfType<PlayerAnim>();
    }
    void Start()
    {

        player = FindObjectOfType<PlayerItems>(); // procurando o objeto na cena
        playerAnim = FindObjectOfType<PlayerAnim>();
    }

    
    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
           playerAnim.OnCastingStarted();
        }
    }
    public void OnCasting()
    {
        int randomValue = Random.Range(1,100);
        
        if(randomValue <= percentage)
        {
            //consegiu pescar
            Debug.Log("Pescou");
        }
        else
        {
            //falhou
            Debug.Log("Nao pescou");
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
