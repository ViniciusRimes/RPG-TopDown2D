using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private float timeMove;
    private PlayerItems playerItems;

    private float timeCount;

    private void Start()
    {
        playerItems = FindObjectOfType<PlayerItems>();
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(playerItems.totalWood < playerItems.woodLimit)
            {
                collision.GetComponent<PlayerItems>().totalWood +=1;
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount < timeMove)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        
    }
}
