using SimpleAudioManager;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int healthGiven;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerHealth>().AddHealth(healthGiven);
            AudioManager.instance.HealthUp();
        }

        if (collision.collider.CompareTag("Shield") && ShieldAnimator.instance.animator.GetBool("ShieldUp") == true)
        {
        }
        else if (collision.collider.CompareTag("Shield") && ShieldAnimator.instance.animator.GetBool("ShieldUp") == false)
        {
            collision.collider.GetComponentInParent<PlayerHealth>().AddHealth(healthGiven);
            AudioManager.instance.HealthUp();
        }

        if (collision.collider.CompareTag("Ground"))
        {
        }

        Destroy(gameObject);
    }
}