using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    Vector3 bar1 = new Vector3(-1.5f, -0.29f, 0.5f); //Spawnpositie van customer bij barX
    Vector3 bar2 = new Vector3(-1.3f, 0.4f, 0.5f);
    Vector3 bar3 = new Vector3(-1f, 1f, 0.5f);
    public Text scoreText; 
    public Text healthText;

    public static int score; //De score waarde
    public static int health; //De health waarde

    private int randomint; //int voor random spawnpositie
    private int bar1Max; //Maximaal klanten per bar
    private int bar2Max;
    private int bar3Max;
    private int bar1Amount; //Huidige klanten (voor de For loop)
    private int bar2Amount;
    private int bar3Amount;
    private bool check1; //Check zodat de klanten niet gespammd worden
    private bool check2;
    private bool check3;

    private float timer1; //Timer (aanpassen via spawnSnelheid)

    public float spawnSnelheid; //De spawn snelheid
    

    public GameObject customerPrefab;

    void Start()
    {
        spawnSnelheid = 4.0f; //Snelheid van spawnen

        bar1Max = 6; //Maximaal aantal klanten die spawnen per bar
        bar2Max = 5;
        bar3Max = 4;

        bar1Amount = 0; //Moet hier altijd 0 blijven
        bar2Amount = 0;
        bar3Amount = 0;

        check1 = false;
        check2 = false;
        check3 = false;
    }

    void Update()
    {
        timer1 = timer1 - Time.deltaTime;
        if (timer1 <= 0)
        {
            timer1 = spawnSnelheid;
            randomint = Random.Range(1,4);
            check1 = false;
            check2 = false;
            check3 = false;
        }


        for(int i = 0; i < bar1Max; i++) //For loops voor het spawnen van de klanten
        {
            if (bar1Amount < bar1Max && randomint == 1 && !check1)
            {
                Instantiate(customerPrefab, bar1, Quaternion.identity);
                bar1Amount++;
                check1 = true;
            }
        }
        for(int i = 0; i < bar2Max; i++)
        {
            if (bar2Amount < bar2Max && randomint == 2 && !check2)
            {
                Instantiate(customerPrefab, bar2, Quaternion.identity);
                bar2Amount++;
                check2 = true;
            }
        }
        for(int i = 0; i < bar3Max; i++)
        {
            if (bar3Amount < bar3Max && randomint == 3 && !check3)
            {
                Instantiate(customerPrefab, bar3, Quaternion.identity);
                bar3Amount++;
                check3 = true;
            }
        }
        scoreText.text = ("Score: " + score);
        healthText.text = ("Health: " + health);
    }
}




