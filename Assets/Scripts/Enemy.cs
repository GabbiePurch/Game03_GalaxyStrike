using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    [SerializeField] int hitPoints = 3;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {

            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }
    }
}
