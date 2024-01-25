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
    public Animator anim;

    public CinematiquesController theCinematique;

    public static bool isGame;
    private bool isFinish;

    public AudioSource sfxProut;
    public AudioSource audioLevel;

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
        anim.SetBool("IsFinish", isFinish);

        if (isGame) 
        { 
            timerPatience += Time.deltaTime;
            barrePatience.value += Time.deltaTime;

            if (barrePatience.value >= 66)
            {
                isFinish = true;
            }

            if (timerPatience > 66.5f)
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
        audioLevel.Stop();
    }

    public void Win()
    {
        sfxProut.Play();
        panelWin.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
