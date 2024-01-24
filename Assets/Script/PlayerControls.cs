using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    const float AxisY = .6f;

    [Header("Stats :")]
    [SerializeField] private int playerLife;
    [SerializeField] private float playerSpeed = 6;

    [Header("Bool")]
    [SerializeField] private bool takeDamage;

    [Header("UI")]
    [SerializeField] private Slider sliderLife;
    [SerializeField] private GameObject life;

    [Header("other :")]
    [SerializeField] private Vector3 initialPosWhenGoNextTo;
    [SerializeField] private Transform[] waysForPlayer;
    [SerializeField] private int indexOfWays;
    [SerializeField] private Animator playerAnims;

    void Start()
    {
        indexOfWays = 2;

        sliderLife.maxValue = playerLife;
        sliderLife.value = playerLife;
    }

    void Update()
    {
        //Quand le joueur perd tout ses pv
        if (playerLife <= 0)
        {
            GameManager.GetInstance().Lose();
        }

        MovingPlayer();

        if (takeDamage)
        {
            StartCoroutine(Invincibility());
        }else
            StopCoroutine(Invincibility());
    }

    void MovingPlayer()
    {
        int nextIndex = indexOfWays;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            

            if (nextIndex <= waysForPlayer.Length - 1)
            {
                playerAnims.SetFloat("direction", 1);
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
                playerAnims.SetFloat("direction", -1);
                nextIndex = indexOfWays - 1;

            }else
            nextIndex = 0;

            transform.position = new Vector3(waysForPlayer[nextIndex].position.x, AxisY);

            indexOfWays = nextIndex;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerAnims.SetFloat("direction", 0);
        }
    }

    private IEnumerator Invincibility()
    {
        yield return new WaitForSeconds(2);
        takeDamage = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy") && takeDamage == false)
        {
            takeDamage = true;

            life.SetActive(true);
            playerLife--;
            sliderLife.value--;
        }
    }
}