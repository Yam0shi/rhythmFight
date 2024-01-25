using UnityEngine;

public class AnimEventsScript : MonoBehaviour
{
    [SerializeField] private GameObject VfxSlash, slashVfx;
    [SerializeField] private GameObject sword;
    [SerializeField] private float Speed = 10;
    [SerializeField] private bool isSpawned;

    private void Update()
    {
        if (isSpawned)
        {
            slashVfx.transform.position += Vector3.forward * Speed * Time.deltaTime;
        }
    }

    public void slash()
    {
        slashVfx = Instantiate(VfxSlash, sword.transform.position,Quaternion.identity);
        isSpawned = true;
    }
}
