using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject panelLose;
    public GameObject panelWin;

    public Slider barrePatience;
    public float timerMax;
    private float timerPatience;
    public static GameManager instance;

    public CinematiquesController theCinematique;

    public static bool isGame;

    #region(singleton)
    private void Awake()
    {
        Time.timeScale = 1.0f;
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of the script");
        }

        instance = this;
    }

    public static GameManager GetInstance()
    {
        return instance;
    }
    #endregion

    private void Start()
    {
        barrePatience.maxValue = 66;
        isGame = false;
    }

    private void Update()
    {
        if (isGame) 
        { 
            timerPatience += Time.deltaTime;
            barrePatience.value += Time.deltaTime;

            if (barrePatience.value >= 66)
            {
                Destroy(GameObject.FindWithTag("Ennemy"));
            }

            if (timerPatience > timerMax && !CinematiquesController.isEnd)
            {
                theCinematique.audioEnd.Play();
                theCinematique.panelEnd.SetActive(true);
                theCinematique.life.SetActive(false);
                CinematiquesController.isEnd = true;
                Time.timeScale = 0.0f;
            }
        }
    }

    public void MyLoadScene(int idScene)
    {
        SceneManager.LoadScene(idScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void Lose()
    {
        panelLose.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Win()
    {
        panelWin.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
