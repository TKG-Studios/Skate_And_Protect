using SimpleAudioManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            AudioManager.instance.PowerUp();
            collision.collider.GetComponent<PlayerHealth>().Invincibility();
            Destroy(gameObject);
        }
    }
}
