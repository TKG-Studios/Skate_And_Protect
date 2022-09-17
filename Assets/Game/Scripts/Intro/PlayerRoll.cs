using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : MonoBehaviour
{
    private float x = 1;
    public float movementSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(x, 0) * movementSpeed * Time.deltaTime;
        transform.Translate(move);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Refuge"))
        {
            Destroy(gameObject);
        }
    }
}
