using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBehaviour : MonoBehaviour
{
    public PlayerBehaviour playerScript;
    public SpriteRenderer sr;
    public Collider2D player;
    public Rigidbody2D rb;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        sr.color = new Color(1, 0, 0);
    }

    // Update is called once per frame
    void Update()   
    {
        if (rb.IsTouching(player) && playerScript.lastCheckpointID < id)
        {
            playerScript.lastCheckpoint = rb.position;
            playerScript.lastCheckpointID = id;
            sr.color = new Color(0, 1, 0);
            playerScript.currentHealth = 30;
        }
    }
}
