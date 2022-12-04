using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
 {
    private bool detectingPlayer; //se o player está na colisão
    [SerializeField] private int percentage; //porcentagem de chance de pescar um peixe
    [SerializeField] private GameObject fishPrefab;

    private PlayerItems playeritems;
    private PlayerAnim playerAnim;
    public bool isCasting;



    private void Awake()
    {   
        playeritems = FindObjectOfType<PlayerItems>(); // procurando o objeto na cena
        playerAnim = FindObjectOfType<PlayerAnim>();
        
    }
    void Start()
    {


    }

    
    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
           
           playerAnim.OnCastingStarted();
           isCasting = true;
           
           
        }
        else
        {
            isCasting = false;
        }
    }
    public void OnCasting()
    {
        int randomValue = Random.Range(1,100);
        
        if(randomValue <= percentage)
        {
            //consegiu pescar
            Instantiate(fishPrefab, playeritems.transform.position + new Vector3(Random.Range(-2f, -1f), 0f, 0f), Quaternion.identity);
    
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
