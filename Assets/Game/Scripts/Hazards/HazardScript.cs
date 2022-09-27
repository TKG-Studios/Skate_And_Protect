using SimpleAudioManager;
using UnityEngine;

public class HazardScript : MonoBehaviour
{
    public int damageGiven = 1;
    public GameObject hazardSpread;
    public int damageMultiplier;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !collision.collider.GetComponent<PlayerHealth>().isInvincible)
        {
            collision.collider.GetComponent<PlayerHealth>().TakeDamage(damageGiven);
        }
        else if (collision.collider.CompareTag("Shield") && ShieldAnimator.instance.animator.GetBool("ShieldUp") == true)
        {
            AudioManager.instance.ShieldHit();
            ShieldHealth.instance.ShieldDamage((float)damageGiven * damageMultiplier);
        }
        else if (collision.collider.CompareTag("Shield") && ShieldAnimator.instance.animator.GetBool("ShieldUp") == false && !collision.collider.GetComponent<ShieldHealth>().invincible)
        {
            collision.collider.GetComponentInParent<PlayerHealth>().TakeDamage(damageGiven);
        }
        else if (collision.collider.CompareTag("Shield") && collision.collider.GetComponent<ShieldHealth>().invincible)
        {
            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("Ground"))
        {
            AudioManager.instance.HazardGround();
            Instantiate(hazardSpread, transform.position, Quaternion.identity);
        }

        if (collision.collider.CompareTag("Hazard"))
        {
            AudioManager.instance.HazardGround();
        }

        Destroy(gameObject);
    }
}