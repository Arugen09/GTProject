using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tr;
    public Collider2D collider;
    public Rigidbody2D rb;
    void onEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.IsTouching(GameObject.Find("Walls").GetComponentInChildren<CompositeCollider2D>()))
        {
            Destroy(this.gameObject);
        }

        if (rb.IsTouching(GameObject.Find("Player").GetComponentInChildren<BoxCollider2D>()))
        {
            GameObject.Find("Player").GetComponentInChildren<Rigidbody2D>().AddForce(rb.velocity * 100);
        }
    }

    public void MoveTowards(Vector2 amount)
    {
        rb.AddForce(amount);
    }
}
