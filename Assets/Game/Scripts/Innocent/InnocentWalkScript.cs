using SimpleAudioManager;
using System.Collections;
using UnityEngine;

public class InnocentWalkScript : MonoBehaviour
{
    private Animator innocentAnimator;
    private float flickerSpeed = 0.05f;
    private SpriteRenderer sprite;

    public float walkDirection;
    public float movementSpeed;

    private int innocentCounter = 1;

    private void Start()
    {
        innocentAnimator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 move = new Vector2(walkDirection, 0) * movementSpeed * Time.deltaTime;
        transform.Translate(move);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Refuge"))
        {
            AudioManager.instance.InnocentSaved();
            PlayerPoints.instance.SavedInnocent(innocentCounter);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Hazard"))
        {
            movementSpeed = 0;
            AudioManager.instance.InnocentLost();
            PlayerPoints.instance.LostInnocent(1);
            Destroy(collision.collider.gameObject);
            innocentAnimator.SetBool("isDead", true);
            StartCoroutine(InnocentDies());
        }
    }

    private IEnumerator InnocentDies()
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
        yield return new WaitForSeconds(flickerSpeed);
        sprite.enabled = false;
        yield return new WaitForSeconds(flickerSpeed);
        Destroy(gameObject);
    }
}