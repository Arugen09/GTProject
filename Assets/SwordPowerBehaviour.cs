using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPowerBehaviour : MonoBehaviour
{
    public Collider2D playerCollider;
    public PlayerBehaviour playerScript;
    public Rigidbody2D powerUpRB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpRB.IsTouching(playerCollider))
        {
            playerScript.hasSword = true;
            Destroy(this.gameObject);
        }
    }
}
