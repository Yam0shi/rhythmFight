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
    private bool isPlay;

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

    private void Update()
    {
        if (nbNextPanel == 1 && !isPlay) 
        { 
            isPlay = true;
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
                    GameManager.isGame = true;
                }
            }
            
            if (isEnd)
            {
                if (nbNextPanel < 7)
                {
                    nbNextPanel++;
                    panelInit = panelCinematique[nbNextPanel];
                    panelInit.SetActive(true);
                }

                if (nbNextPanel >= 7)
                {
                    panelEnd.SetActive(false);
                    audioEnd.Stop();
                    isEnd = false;
                    GameManager.isGame = false;
                    theManager.Win();
                }
            }
        }
    }
}
