using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed; //velocidade do npc
    private float initialSpeed;
    public List <Transform> paths = new List<Transform>();

    private int index; //ver qual path o npc esta seguindo

    private Animator anim;
    
    
    void Start()
    {
        initialSpeed = speed;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(DialogueControl.instance.isShowing)
        {
            speed = 0f;
            anim.SetBool("isWalking", false);
        }
        else
        {
            speed = initialSpeed;
            anim.SetBool("isWalking", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed *Time.deltaTime);
        

        if(Vector2.Distance(transform.position, paths[index].position )< 0.1f)
        {
        
           if(index < paths.Count - 1)
           {
                index++;
           } 
           else
           {
                index = 0;
           }
        }

        Vector2 direction = paths[index].position - transform.position;
        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        if(direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }
}
