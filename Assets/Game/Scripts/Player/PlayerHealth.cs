using SimpleAudioManager;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int maxHealth;
    public bool isInvincible;

    [HideInInspector]
    public int health;
    public float invinciblityInitialTimer = 5;
    public float invinciblityTimer;
    public SpriteRenderer[] sprites;
    private BoxCollider2D col;

    private float flickerSpeed = 0.05f;

    private void Start()
    {
        invinciblityTimer = invinciblityInitialTimer;
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

    public void Invincibility()
    {
        isInvincible = true;
        LevelMusic.instance.playTrack3(); 
        StartCoroutine(ColorFlicker());
       
      
    }

    private IEnumerator ColorFlicker()
    {
 
      
        while (isInvincible)
        {
           
            sprites[0].color = Color.yellow;
            yield return new WaitForSeconds(flickerSpeed);
            sprites[0].color = Color.white;
            yield return new WaitForSeconds(flickerSpeed);
            invinciblityTimer -= 10 * Time.deltaTime;
            Debug.Log(invinciblityTimer);
            if (invinciblityTimer <= 0)
            {
                isInvincible = false;
                invinciblityTimer = invinciblityInitialTimer;
                LevelMusic.instance.playTrack1();
            }
        }

     
    }
    private IEnumerator FlickerSprite()
    {
        col.enabled = false;
        if (health > (maxHealth - 1))
        {
            if (sprites != null)
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
        }
        
        col.enabled = true;
        yield return null;
    }
}