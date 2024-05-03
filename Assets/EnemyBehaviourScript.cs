using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform tr;
    public GameObject PlayerSprite;
    public GameObject firePreFab;
    public bool shouldStartTimer = false;
    public float time = 0.5f;
    public bool cutsceneDone = false;

    public int phase = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSprite = GameObject.Find("Player");
        this.gameObject.AddComponent<OriginalCutscene>();
        rb.velocity = new Vector2(10, 0);
        phase = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!cutsceneDone)
        {
            if (phase == 1  && rb.position.x < 41)
            {
                rb.velocity = new Vector2(10, 0);
            }
            else if (rb.position.x >= 41 && phase == 1)
            {
                phase += 1;
            }

            if (phase == 2 && rb.position.y > -15.5)
            {
                rb.velocity = new Vector2(0, -10);
            }
            else if (phase == 2 && rb.position.y <= -15.5)
            {
                phase = 3;
            }

            if (phase == 3 && rb.position.x > 26.5)
            {
                rb.velocity = new Vector2(-11, 0);
                print(rb.position);
            }
            else if (phase == 3 && rb.position.x <= 26.52)
            {
                phase = 4;
                
            }

            if (phase == 4)
            {
                cutsceneDone = true;
                phase = 5;
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

                    clone.BroadcastMessage("MoveTowards", (PlayerSprite.GetComponent<Rigidbody2D>().position - rb.position) * 30);
                }
            }
        }
    }

}
