using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;

    public bool playerHit;

    public DialogueSettings Dialogue;

    private List<string> sentences = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() //chamado a cada frame
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());;
        }
    }

    void GetTexts()
    {
        for(int i = 0; i < Dialogue.Dialogues.Count; i++)
        {
            sentences.Add(Dialogue.Dialogues[i].sentence.portuguese);
        }
    }

    
    void FixedUpdate() //usado pela física
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null)
        {
            playerHit = true;

        }
        else
        {
            playerHit = false;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
        
    }

}