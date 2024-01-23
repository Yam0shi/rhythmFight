using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    [Header("Stats :")]
    [SerializeField] private int playerLife;
    [SerializeField] private float playerSpeed;

    [Header("Script")]
    [SerializeField] private GameManager theManager;

    [Header("Bool")]
    [SerializeField] private bool takeDamage;

    [Header("UI")]
    [SerializeField] private Slider sliderLife;
    [SerializeField] private GameObject life;

    void Start()
    {
        theManager = gameObject.AddComponent<GameManager>();

        sliderLife.maxValue = playerLife;
        sliderLife.value = playerLife;
    }

    void Update()
    {
        //Quand le joueur perd tout ses pv
        if (playerLife <= 0)
        {
            theManager.Lose();
        }

        //Test pour voir si la barre s'affiche de vie, et qu'on perd des pv
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            life.SetActive(true);
            playerLife--;
            sliderLife.value--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            takeDamage = true;
        }
    }
}
