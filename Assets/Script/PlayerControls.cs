using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Stats :")]
    [SerializeField] private int playerLife;
    [SerializeField] private float playerSpeed;

    void Start()
    {
            playerLife = 3;
    }

    void Update()
    {
        
    }
}
