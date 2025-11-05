using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    bool shieldActive = false;
    float shieldTimer = 0f;

    private void Update()
    {
        if (shieldActive)
        {
            shieldTimer -= Time.deltaTime;

            if (shieldTimer <= 0f)
            {
                shieldActive = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shield"))
        {
            shieldActive = true;
            shieldTimer = 5f;

            Destroy(other.gameObject);
            return;
        }

        if (shieldActive) return;
        Instantiate(destroyVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
