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

    [Header("other :")]
    [SerializeField] private Vector3 initialPosWhenGoNextTo;
    [SerializeField] private Transform[] waysForPlayer;
    [SerializeField] private int indexOfWays;
    [SerializeField] private Animator playerAnims;
    [SerializeField] private GameObject chutTest;
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
        LifeGestion();

        if (takeDamage)
        {
            Debug.Log("invincibilité activé");
            StartCoroutine(Invincibility());
        }
        else
        {
            Debug.Log("invincibilité désactivé");
            StopCoroutine(Invincibility());
        }
    }

    void LifeGestion()
    {
        sliderLife.GetComponent<RectTransform>().position =  Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z));
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
        chutTest.SetActive(true);
        yield return new WaitForSeconds(2);
        chutTest.SetActive(false);
        takeDamage = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            if(takeDamage == false)
            {
                takeDamage = true;

                playerLife--;
                sliderLife.value--;
            }
            Destroy(other.gameObject);
        }
    }
}