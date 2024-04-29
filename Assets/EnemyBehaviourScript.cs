using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed;
    public GameObject PlayerSprite;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSprite = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
