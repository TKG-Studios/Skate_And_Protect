using SimpleAudioManager;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int maxHealth;

    [HideInInspector]
    public int health;

    public SpriteRenderer[] sprites;
    private BoxCollider2D col;

    private float flickerSpeed = 0.05f;

    private void Start()
    {
        instance = this;
        health = maxHealth;
        col = GetComponent<BoxCollider2D>();
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(FlickerSprite());
        health -= damage;
        AudioManager.instance.PlayerHit();
        if (health <= 0)
        {
            health = 0;

            if (health == 0)
            {
                GameManager.instance.changeState(GameManager.GameStates.GameOver);

                //StartCoroutine(DestroyPlayer());
            }
        }
    }

    public void AddHealth(int healthGiven)
    {
        health += healthGiven;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    //private IEnumerator DestroyPlayer()
    //{
    //    yield return new WaitForSeconds(.05f);
    //    Destroy(sprites[0]);
    //}

    private IEnumerator FlickerSprite()
    {
        col.enabled = false;
        if (health > (maxHealth - 1))
        {
            foreach (SpriteRenderer sprite in sprites)
            {
                sprite.enabled = false;
                yield return new WaitForSeconds(flickerSpeed);
                sprite.enabled = true;
                yield return new WaitForSeconds(flickerSpeed);
                sprite.enabled = false;
                yield return new WaitForSeconds(flickerSpeed);
                sprite.enabled = true;
                yield return new WaitForSeconds(flickerSpeed);
                sprite.enabled = false;
                yield return new WaitForSeconds(flickerSpeed);
                sprite.enabled = true;
            }
        }
        
        col.enabled = true;
        yield return null;
    }
}