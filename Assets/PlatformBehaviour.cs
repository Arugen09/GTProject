using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D playerCollider;
    public PlayerBehaviour playerScript;
    public bool isMovingHorizontal;
    public float speed = 2;
    public float lowerLimit;
    public float upperLimit;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GameObject.Find("Player").GetComponent<Collider2D>();
        if (isMovingHorizontal)
        {
            rb.velocity = new Vector2(speed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(0f, speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingHorizontal)
        {
            if (rb.position.x <= lowerLimit)
            {
                rb.velocity = new Vector2(speed, 0f);
            }
            else if (rb.position.x >= upperLimit)
            {
                rb.velocity = new Vector2(-speed, 0f);
            }
        }
        else
        {
            if (rb.position.y <= lowerLimit)
            {
                rb.velocity = new Vector2(0f, speed);
            }
            else if (rb.position.y >= upperLimit)
            {
                rb.velocity = new Vector2(0f, -speed);
            }
        }
        if (rb.IsTouching(playerCollider))
        {
            playerScript.velocityModifier = rb.velocity;
        }

    }
}
