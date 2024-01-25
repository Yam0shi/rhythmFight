using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    const float AxisY = .6f;

    [Header("Stats :")]
    [SerializeField] private int playerLife;

    [Header("Bool")]
    [SerializeField] private bool takeDamage;

    [Header("UI")]
    [SerializeField] private Image lifeImage;
    [SerializeField] private Sprite[] LifeVisual;

    [Header("other :")]
    [SerializeField] private Transform[] waysForPlayer;
    private int indexOfWays;
    [SerializeField] private Animator playerAnims;
    [SerializeField] private GameObject chutTest;
    
    void Start()
    {
        indexOfWays = 2;
    }

    void Update()
    {
        if (playerLife <= 0)
            GameManager.GetInstance().Lose();

        MovingPlayer();
        LifeGestion();

        if (takeDamage)
            StartCoroutine(Invincibility());
        else
            StopCoroutine(Invincibility());
    }

    public void LifeGestion()
    {
        lifeImage.rectTransform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y +1.5f, transform.position.z));

        if (playerLife == 3)
            lifeImage.sprite = LifeVisual[0];
        else if (playerLife == 2)
            lifeImage.sprite = LifeVisual[1];
        else if (playerLife == 1)
            lifeImage.sprite = LifeVisual[2];
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

    private IEnumerator ShakeCamera(float duration, float magnitude)
    {
        Vector3 originalPos = Camera.main.transform.position;
        float elapsed = 0;

        while (elapsed < duration)
        {
            float x = Random.Range(-1, 1) * magnitude;

            Camera.main.transform.localPosition = new Vector3(x, originalPos.y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        Camera.main.transform.position = originalPos;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            if(takeDamage == false)
            {
                takeDamage = true;
                playerLife--;
            }
            Destroy(other.gameObject);
            StartCoroutine(ShakeCamera(1, .2f));
        }
    }
}