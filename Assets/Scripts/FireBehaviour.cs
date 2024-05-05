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
        if (GameObject.Find("SingleBrick(Clone)") != null)
        {
            if (rb.IsTouching(GameObject.Find("Walls").GetComponentInChildren<CompositeCollider2D>()) || rb.IsTouching(GameObject.Find("SingleBrick(Clone)").GetComponent<Collider2D>()) || rb.IsTouching(GameObject.Find("BossWalls").GetComponentInChildren<CompositeCollider2D>()))
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (rb.IsTouching(GameObject.Find("Walls").GetComponentInChildren<CompositeCollider2D>()) || rb.IsTouching(GameObject.Find("BossWalls").GetComponentInChildren<CompositeCollider2D>()))
            {
                Destroy(this.gameObject);
            }
        }
        if (rb.IsTouching(GameObject.Find("Player").GetComponent<Collider2D>()))
        {
            GameObject.Find("Player").GetComponent<PlayerBehaviour>().currentHealth -= 1;
            Destroy(this.gameObject);
        }
    }

    public void MoveTowards(Vector2 amount)
    {
        rb.velocity = amount;
    }
}
