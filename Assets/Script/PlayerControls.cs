using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    const float AxisY = .6f;

    [Header("Stats :")]
    [SerializeField] private int playerLife;
    [SerializeField] private float playerSpeed = 6, jumpSpeed = 8;

    [Header("Script")]
    [SerializeField] private GameManager theManager;

    [Header("Bool")]
    [SerializeField] private bool takeDamage;

    [Header("UI")]
    [SerializeField] private Slider sliderLife;
    [SerializeField] private GameObject life;

    [Header("other :")]
    [SerializeField] private Vector3 initialPosWhenGoNextTo;
    [SerializeField] private Transform[] waysForPlayer;
    [SerializeField] private int indexOfWays;

    void Start()
    {
        theManager = gameObject.AddComponent<GameManager>();

        indexOfWays = 2;

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

        MovingPlayer();
    }

    void MovingPlayer()
    {
        int nextIndex = indexOfWays;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            

            if (nextIndex <= waysForPlayer.Length - 1)
            {
                nextIndex = indexOfWays + 1;
            }else
            nextIndex = 4;

            transform.position = new Vector3(waysForPlayer[nextIndex].position.x, AxisY);

            indexOfWays = nextIndex;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (nextIndex >= 0)
            {
                nextIndex = indexOfWays - 1;

            }else
            nextIndex = 0;

            transform.position = new Vector3(waysForPlayer[nextIndex].position.x, AxisY);

            indexOfWays = nextIndex;
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
