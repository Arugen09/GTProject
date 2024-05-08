using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public Collider2D playerCollider;
    public float moveSpeed;
    private Camera camera;
    public Transform playerTransform;
    public HealthBar healthBar;
    public int currentHealth = 30;
    public float dashSpeed;
    public float coolDownTime = 0f;
    public bool isInBossRoom = true;
    public bool hasDowned;
    public Vector2 lastCheckpoint;
    public int lastCheckpointID = 0;
    public Vector2 velocityModifier = Vector2.zero;
    public GameObject platform;
    public CompositeCollider2D waterCollider;
    public CompositeCollider2D floorCollider;
    public Rigidbody2D waterBody;
    public bool hasSword = false;
    public SwordBehaviour swordScript;
    public float finalAngle = 0;
    public float middleAngle = 0;
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
        if (currentHealth <= 0)
        {
            hasDied();
        }
        if (GameObject.Find("CameraScript").GetComponent<CameraScript>().isFollowing || isInBossRoom)
        {
            bool isTouchingPlatform = false;
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Platform"))
            {
                if (item.GetComponent<Rigidbody2D>().IsTouching(playerCollider))
                {
                    isTouchingPlatform = true;
                }
            }
            if ((playerRB.IsTouching(waterCollider) || waterCollider.bounds.Contains(new Vector3(playerRB.position.x, playerRB.position.y, 0f))) && !isTouchingPlatform)
            {
                //currentHealth = 0;
            }
            if (!isTouchingPlatform)
            {
                velocityModifier = Vector2.zero;
            }
            playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed) + velocityModifier;

            if (!hasSword)
            {
                
                if (Input.GetMouseButton(0) && !hasDowned && coolDownTime <= 0)
                {
                    coolDownTime = 2f;
                    Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
                    mousePos.z = 0;

                    if (mousePos.x < playerTransform.position.x - 0.5 || mousePos.x > playerTransform.position.x + 0.5 || mousePos.y > playerTransform.position.y + 0.5 || mousePos.y < playerTransform.position.y - 0.5)
                    {
                        hasDowned = true;
                        Vector2 relativePos = new Vector2((mousePos.x - playerTransform.position.x), (mousePos.y - playerTransform.position.y));
                        if (relativePos.magnitude > 5)
                        {
                            float xDistance = (float)System.Math.Cos(System.Math.Atan(relativePos.y / relativePos.x)) * 5;
                            float yDistance = (float)System.Math.Sin(System.Math.Atan(relativePos.y / relativePos.x)) * 5;

                            if (relativePos.x < 0)
                            {
                                yDistance *= -1f;
                                xDistance *= -1f;
                            }
                            LayerMask mask = LayerMask.GetMask("Walls");
                            RaycastHit2D hit2D = Physics2D.Raycast(playerRB.position, new Vector2(xDistance, yDistance), (new Vector2(xDistance, yDistance)).magnitude, mask);
                            Vector2 finalChange = new Vector2(xDistance, yDistance);
                            if (hit2D.collider != null)
                            {
                                finalChange = finalChange * ((hit2D.distance - 0.5f) / (finalChange.magnitude));
                            }
                            playerTransform.Translate(finalChange.x, finalChange.y, 0f);
                        }
                        else
                        {
                            float xDistance = relativePos.x;
                            float yDistance = relativePos.y;

                            LayerMask mask = LayerMask.GetMask("Walls");
                            RaycastHit2D hit2D = Physics2D.Raycast(playerRB.position, new Vector2(xDistance, yDistance), (new Vector2(xDistance, yDistance)).magnitude, mask);
                            Vector2 finalChange = new Vector2(xDistance, yDistance);
                            if (hit2D.collider != null)
                            {
                                finalChange = finalChange * ((hit2D.distance - 0.5f) / (finalChange.magnitude));
                            }
                            playerTransform.Translate(finalChange.x, finalChange.y, 0f);
                        }

                    }
                }
            }
            else if (hasSword)
            {
                if (Input.GetMouseButton(0) && !hasDowned && coolDownTime <= 0)
                {
                    hasDowned = true;
                    coolDownTime = 2f;


                    Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 relativePos = new Vector2((mousePos.x - playerTransform.position.x), (mousePos.y - playerTransform.position.y));

                    float angle = (float)System.Math.Atan(relativePos.y / relativePos.x) * 180f / Mathf.PI;
                    if (relativePos.x < 0 && relativePos.y < 0)
                    {
                        angle += 135;
                    }
                    else if(relativePos.x < 0)
                    {
                        angle += 135;
                    }
                    else if (angle < 0)
                    {
                        angle += 315;
                    }
                    else
                    {
                        if (angle >= 45)
                        {
                            angle -= 45;
                        }
                        else
                        {
                            angle += 315;
                        }
                    }


                    float startAngle = angle + 45f;
                    if (startAngle >= 360)
                    {
                        startAngle -= 360;
                    }
                    finalAngle = startAngle - 45f;
                    if (finalAngle < 0)
                    {
                        finalAngle += 360;
                    }
                    swordScript.beginningAngle = startAngle;
                    swordScript.middleAngle = startAngle;
                    swordScript.finalAngle = finalAngle;
                    swordScript.isSlashing = true;
                }
            }

            if (!Input.GetMouseButton(0))
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

    public void hasDied()
    {
        if (lastCheckpointID == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            playerTransform.position = lastCheckpoint;
            currentHealth = 30;
            coolDownTime = 0;
        }
    }
}