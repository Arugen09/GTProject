using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Transform tr;
    public GameObject PlayerSprite;
    public GameObject firePreFab;
    public bool shouldStartTimer = false;
    public GameObject heatWave;
    public float time = 0.5f;
    public bool cutsceneDone = false;
    public GameObject brickPreFab;
    public int phase = 0;
    public Collider2D playerCollider;
    public PlayerBehaviour playerScript;
    public float tempTime = 2f;
    public Sprite[] bossSprites;
    private bool hasPlayerMoved = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSprite = GameObject.Find("Player");
        phase = 1;
        print(rb.position);
        bossSprites = Resources.LoadAll<Sprite>("Sprites/BossSprites");
        if ((Vector2) rb.position == new Vector2(-58f, -22.5f))
        {
            Destroy(GetComponent<EnemyBehaviourScript>());
        }
        else
        {
            spriteRenderer.sprite = bossSprites[2];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasPlayerMoved && Input.anyKey)
        {
            hasPlayerMoved = true;
        }
        if (!cutsceneDone && hasPlayerMoved)
        {
            if (rb.IsTouching(playerCollider))
            {
                playerScript.currentHealth = 0;
            }

            if (phase == 1  && rb.position.x < 41)
            {

                rb.velocity = new Vector2(12.5f, 0);
            }
            else if (rb.position.x >= 41 && phase == 1)
            {
                phase += 1;
                Instantiate(heatWave, tr);
                Instantiate(heatWave, tr);
                Instantiate(heatWave, tr);
                Instantiate(heatWave, tr);
                spriteRenderer.sprite = bossSprites[1];
            }

            if (phase == 2 && rb.position.y > -15)
            {
                rb.velocity = new Vector2(0, -12.5f);
            }
            else if (phase == 2 && rb.position.y <= -15)
            {
                phase = 3;
                tr.localScale = new Vector3(-1f, 1f, 1f);
                spriteRenderer.sprite = bossSprites[2];
            }

            if (phase == 3 && rb.position.x > 26.52)
            {
                rb.velocity = new Vector2(-13.5f, 0);
            }
            else if (phase == 3 && rb.position.x <= 26.52)
            {
                phase = 4;
                
            }

            if (phase == 4)
            {
                phase = 5;
                rb.velocity = Vector2.zero;
                Instantiate(brickPreFab, new Vector2((float) 23.5, (float) -15), Quaternion.identity);
                rb.velocity = new Vector2(0f, 0f);
                Instantiate(heatWave, tr);
                Instantiate(heatWave, tr);
                Instantiate(heatWave, tr);
                Instantiate(heatWave, tr);
            }

            if (phase == 5 && tempTime > 0f)
            {
                tempTime -= Time.deltaTime;
            } else if (phase == 5 && tempTime <= 0f)
            {
                phase = 6;
            }

            if (phase == 6 && rb.position.x < 41)
            {
                rb.velocity = new Vector2(5f, 0f);
                tr.localScale = new Vector3(1f, 1f, 1f);
                
            }  else if (phase == 6 && rb.position.x >= 41)
            {
                rb.velocity = Vector2.zero;
                cutsceneDone = true;
            }
            
        
        }
        if (cutsceneDone)
        {
            if (Vector3.Distance(PlayerSprite.GetComponent<Transform>().position, tr.position) < 7)
            {
                if (!shouldStartTimer)
                {
                    time = 0.5f;
                }
                shouldStartTimer = true;
                
            }
            else
            {
                shouldStartTimer = false;
            }

            if (shouldStartTimer)
            {
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    GameObject clone = Instantiate(firePreFab, tr.position, Quaternion.identity);
                    time = 0.5f;

                    // float angle = Vector2.Angle(rb.position, PlayerSprite.GetComponent<Rigidbody2D>().position);
                    // Debug.Log(angle);
                    float dashSpeed = 20;
                    Vector2 relativePos = PlayerSprite.GetComponent<Rigidbody2D>().position - rb.position;
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
                    clone.GetComponent<Rigidbody2D>().velocity = forceToApply;
                }
            }
        }
    }

}
