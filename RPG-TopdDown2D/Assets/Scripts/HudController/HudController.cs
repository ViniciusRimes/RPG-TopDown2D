using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HudController : MonoBehaviour
{
    private PlayerItems playerItems;

    private Player player;

    
    
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image fishUIBar;


    [Header("Tools")]

    public List <Image> ToolsUI = new List<Image>();
    [SerializeField] private Color colorImage;
    [SerializeField] private Color alphaColor;

    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        fishUIBar.fillAmount = 0f;
        
        playerItems = FindObjectOfType<PlayerItems>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        waterUIBar.fillAmount = playerItems.currentWater / playerItems.waterLimit ;
        woodUIBar.fillAmount = playerItems.totalWood / playerItems.woodLimit;
        carrotUIBar.fillAmount = playerItems.totalCarrot / playerItems.carrotLimit;
        fishUIBar.fillAmount = playerItems.totalfishes / playerItems.fishesLimit;
        

        //ToolsUI[player.handlingObj].color = colorimage;

        for(int i = 0; i < ToolsUI.Count; i++)
        {
            if(i == player.handlingObj)
            {
                ToolsUI[i].color = colorImage;
            }
            else
            {
                ToolsUI[i].color = alphaColor;
            }
        }

    }

}