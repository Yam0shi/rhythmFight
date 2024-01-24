using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematiquesController : MonoBehaviour
{
    private int nbNextPanel;

    public GameObject[] panelCinematique;
    private GameObject panelInit;
    public GameObject cinematique;
    public GameObject level;

    private void Start()
    {
        panelInit = panelCinematique[0];
        panelInit.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            if (nbNextPanel < 10) 
            { 
                nbNextPanel++;
                panelInit = panelCinematique[nbNextPanel];
                panelInit.SetActive(true);
            }

            if (nbNextPanel >= 10) 
            { 
                cinematique.SetActive(false);
                level.SetActive(true);
            }
        }
    }
}
