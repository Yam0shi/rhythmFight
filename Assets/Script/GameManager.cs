using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject panelLose;
    public GameObject panelWin;

    public Slider barrePatience;
    public float timerMax;
    private float timerPatience;

    private void Start()
    {
        barrePatience.maxValue = timerMax;
    }

    private void Update()
    {
        timerPatience += Time.deltaTime;
        barrePatience.value += Time.deltaTime;

        if (timerPatience > timerMax)
        {
            Win();
        }
    }

    public void MyLoadScene(int idScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(idScene);
        Time.timeScale = 1.0f;
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
