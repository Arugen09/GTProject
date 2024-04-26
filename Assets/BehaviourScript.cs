using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * 10, Input.GetAxis("Vertical") * 10));
        }        
    }
}
