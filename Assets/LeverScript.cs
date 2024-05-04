using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool hasBeenPressed = false;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.IsTouching(GameObject.Find("Player").GetComponent<Collider2D>()) && !hasBeenPressed)
        {
            hasBeenPressed = true;
            print("TOUCHING!!!");
            sr.sprite = Resources.Load<Sprite>("Sprites/leverOn");

            
        }
    }
}
