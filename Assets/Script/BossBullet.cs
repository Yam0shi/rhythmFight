using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DestructionWall"))
        {
            Destroy(gameObject);
        }

    }
}
