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
    public GameObject level, life;

    public static bool isFinishIntro, isEnd;

    public AudioSource audioIntro1, audioIntro2;
    public AudioSource audioEnd;

    private void Start()
    {
        isFinishIntro = false;
        isEnd = false;
        panelInit = panelCinematique[0];
        panelInit.SetActive(true);   
        level.SetActive(false);
        life.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (nbNextPanel == 1) 
        { 
            audioIntro1.Stop();
            audioIntro2.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            if (!isFinishIntro) 
            { 
                if (nbNextPanel < 2) 
                { 
                    nbNextPanel++;
                    panelInit = panelCinematique[nbNextPanel];
                    panelInit.SetActive(true);
                }
                else if (nbNextPanel >= 2) 
                { 
                    nbNextPanel++;
                    panelInit = panelCinematique[nbNextPanel];
                    panelIntro.SetActive(false);
                    audioIntro2.Stop();
                    level.SetActive(true);
                    life.SetActive(true);
                    isFinishIntro = true;
                }
            }
            
            if (isEnd)
            {
                if (nbNextPanel < 8)
                {
                    nbNextPanel++;
                    panelInit = panelCinematique[nbNextPanel];
                    panelInit.SetActive(true);
                }

                if (nbNextPanel >= 8)
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
