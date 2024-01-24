using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematiquesController : MonoBehaviour
{
    public GameManager theManager;

    private int nbNextPanel;

    public GameObject[] panelCinematique;
    private GameObject panelInit;
    public GameObject panelIntro, panelEnd;
    public GameObject level;

    public static bool isFinishIntro, isEnd;

    private void Start()
    {
        isFinishIntro = false;
        isEnd = false;
        panelInit = panelCinematique[0];
        panelInit.SetActive(true);        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            if (!isFinishIntro) 
            { 
                if (nbNextPanel < 10) 
                { 
                    nbNextPanel++;
                    panelInit = panelCinematique[nbNextPanel];
                    panelInit.SetActive(true);
                }

                if (nbNextPanel >= 10) 
                { 
                    nbNextPanel++;
                    panelInit = panelCinematique[nbNextPanel];
                    panelIntro.SetActive(false);
                    level.SetActive(true);
                    isFinishIntro = true;
                }
            }
            
            if (isEnd)
            {
                if (nbNextPanel < 20)
                {
                    nbNextPanel++;
                    panelInit = panelCinematique[nbNextPanel];
                    panelInit.SetActive(true);
                }

                if (nbNextPanel >= 20)
                {
                    panelIntro.SetActive(false);
                    level.SetActive(true);
                    isEnd = false;
                    theManager.Win();
                }
            }
        }
    }
}
