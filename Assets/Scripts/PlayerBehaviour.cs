using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    private Camera camera;
    public Transform transform;
    public HealthBar healthBar;
    public int currentHealth = 30;
    public float dashSpeed;
    public float coolDownTime = 2f;
    public bool isInBossRoom = true;
    private bool hasDowned;

    // Start is called before the first frame update
    void Start()
    {
        
        camera = GameObject.Find("CameraScript").GetComponent<Camera>();
        dashSpeed *= -1;
        hasDowned = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        updateHealth();
        if (GameObject.Find("CameraScript").GetComponent<CameraScript>().isFollowing || isInBossRoom)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);

            if (Input.GetMouseButton(0) && !hasDowned && coolDownTime <= 0)
            {
                coolDownTime = 2f;
                Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;

                if (mousePos.x < transform.position.x - 0.5 || mousePos.x > transform.position.x + 0.5 || mousePos.y > transform.position.y + 0.5 ||  mousePos.y < transform.position.y - 0.5)
                {
                    hasDowned = true;
                    Vector2 relativePos = new Vector2((mousePos.x - transform.position.x), (mousePos.y - transform.position.y));
                    if (relativePos.magnitude > 5)
                    {
                        double xDistance = System.Math.Cos(System.Math.Atan(relativePos.y / relativePos.x)) * 5;
                        double yDistance = System.Math.Sin(System.Math.Atan(relativePos.y / relativePos.x)) * 5;
                        if (relativePos.x < 0)
                        {
                            yDistance *= -1;
                            xDistance *= -1;
                        }

                        transform.Translate((float) xDistance, (float) yDistance, 0f);
                    }
                    else
                    {
                        int x = 0;
                        transform.Translate((float) relativePos.x, (float) relativePos.y, 0f);
                    }

                }
            }
            else if (!Input.GetMouseButton(0))
            {
                hasDowned = false;
            }
        }
        if (!hasDowned && coolDownTime > 0f)
        {
            coolDownTime -= Time.deltaTime;
        }
        
    }

    void updateHealth()
    {
        healthBar.SetHealth(currentHealth);
    }

    public void damage(int amount)
    {
        currentHealth -= amount;
    }

    public void findClosestTraversablePoint()
    {

    }
}