using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScrit : MonoBehaviour
{
    public PlayerBehaviour pb;
    public Collider2D pc;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public bool hasBeenCollected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.IsTouching(pc) && !hasBeenCollected)
        {
            pb.coolDownTime = 0;
            hasBeenCollected = true;
            sr.sortingOrder = 0;
        }

        if (pb.currentHealth == 0 && hasBeenCollected)
        {
            hasBeenCollected = false;
            sr.sortingOrder = 4;
        }
    }
}
