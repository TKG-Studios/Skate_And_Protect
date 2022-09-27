using SimpleAudioManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float randomX;
    public float randomY;
    private void Start()
    {
        randomX = Random.Range(-500, -200);
        randomY = Random.Range(25, 100);
        GetComponent<Rigidbody2D>().AddForce(new Vector3(randomX, randomY, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Shield"))
        {
            AudioManager.instance.PowerUp();
            collision.GetComponent<PlayerHealth>().Invincibility();
            Destroy(gameObject);
        }
    }
}
