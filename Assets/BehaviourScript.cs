using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    private Camera camera;
    public Transform transform;

    public float dashSpeed;
    

    private bool hasDowned;

    // Start is called before the first frame update
    void Start()
    {
        
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        dashSpeed *= -1;
        hasDowned = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);

        if (Input.GetMouseButton(0) && !hasDowned)
        {
            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            if (mousePos.x < transform.position.x - 0.5 || mousePos.x > transform.position.x + 0.5 || mousePos.y > transform.position.y + 0.5 ||  mousePos.y < transform.position.y - 0.5)
            {
                hasDowned = true;
                Vector2 relativePos = new Vector2((transform.position.x - mousePos.x), (transform.position.y - mousePos.y));

                Vector2 forceToApply = new Vector2(0, 0);
                double xDistance = System.Math.Cos(System.Math.Atan(relativePos.y / relativePos.x)) * dashSpeed;
                double yDistance = System.Math.Sin(System.Math.Atan(relativePos.y / relativePos.x)) * dashSpeed;
                
                if (relativePos.y == 0)
                {
                    if (relativePos.x < 0)
                    {
                        forceToApply = new Vector2(-dashSpeed, 0);
                    }
                    else if (relativePos.x > 0)
                    {
                        forceToApply = new Vector2(dashSpeed, 0);
                    }
                }
                else if (relativePos.y < 0)
                {
                    if (relativePos.x > 0)
                    {
                        forceToApply = new Vector2((float) xDistance, (float) yDistance);
                    }
                    else
                    {
                        forceToApply = new Vector2((float) xDistance * -1, (float) yDistance * -1);
                    }
                }
                else
                {
                    if (relativePos.x > 0)
                    {
                        forceToApply = new Vector2((float) xDistance, (float) yDistance);
                    }
                    else
                    {
                        forceToApply = new Vector2((float) xDistance * -1, (float) yDistance * -1);
                    }
                }
                
                rb.AddForce(forceToApply);
            }
        }
        else if (!Input.GetMouseButton(0))
        {
            hasDowned = false;
        }
        
    }
}