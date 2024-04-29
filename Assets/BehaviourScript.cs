using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    private Camera camera;
    public Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Vector2 relativePos = new Vector2(-10 * (transform.position.x - mousePos.x), -10 * (transform.position.y - mousePos.y));

            rb.AddForce(relativePos);
        }

        
    }
}