using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj; //janela do diálogo
    public Image profileSprite; //sprite do perfil
    public Text speechText; // texto da fala
    public Text actorNameText; //nome do Npc


    [Header("Setting")]
    public float typingSpeed; // velocidade da fala

    //Variáveis de controle;
    private bool isShowing; //se a janela está visível
    private int index; //variável de controle de um loop de repetição das falas
    private string[] sentences;

    public static DialogueControl instance;

    public void Awake() //Awake é chamado antes de todos os Start() na hierarquia da execucao dos scripts
    {
        instance = this;
    }
    
    
    
    void Start() //executado ao iniciar
    {
        
    }


    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Speech(string[] txt) //chamar a fala
    {
        if(!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }

    public void NextSentence() // pular para a próxima fala
    {

    }



}
