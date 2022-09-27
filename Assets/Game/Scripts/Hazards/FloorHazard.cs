using UnityEngine;

public class FloorHazard : MonoBehaviour
{
    public int damageGiven = 1;
    public float timeToLive;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Shield") && !collision.collider.GetComponent<ShieldHealth>().invincible)
        {
           
                collision.collider.GetComponentInParent<PlayerHealth>().TakeDamage(damageGiven);
            Destroy(gameObject);
           
        } else if (collision.collider.CompareTag("Shield") && collision.collider.GetComponent<ShieldHealth>().invincible)
        {
            Destroy(gameObject);
        }
            

        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerHealth>().TakeDamage(damageGiven);
            Destroy(gameObject);

        } else if (collision.collider.CompareTag("Player") && collision.collider.GetComponent<PlayerHealth>().isInvincible)
        {
            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("Health"))
        {
            
        }

       


    }

    private void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
        {
            Destroy(gameObject);
        }
    }
}