using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public float coolDown = 3f;
    public Rigidbody2D rb;
    public Transform tr;
    public Collider2D collider;
    public GameObject PlayerSprite;
    public GameObject firePreFab;
    public float time = 0.5f;
    public bool isNowBoss = false;
    public GameObject heatWaveSystem;
    public int attacksLeft = 0;
    public float bossHealth = 50;
    public HealthBar healthScript;

    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
        
        if ((Vector2) rb.position == new Vector2(-58f, -22.5f))
        {
            Destroy(this.gameObject.GetComponent<EnemyBehaviourScript>());
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            isNowBoss = true;
        }
        if (isNowBoss)
        {
            healthScript.SetHealth((int) bossHealth);
            if (bossHealth <= 0)
            {
                collider.isTrigger = true;
                Destroy(this);
            }
            if (coolDown >= 0)
            {
                coolDown -= Time.deltaTime;
            }

            if (coolDown <= 0 && attacksLeft == 0)
            {
                int choice = (int)(Random.value * 2) + 1;
                if (choice > 1)
                {
                    coolDown = 0.5f;
                    attacksLeft = choice;
                    heatWave();
                }
                else
                {
                    heatWave();
                    coolDown = 5f;
                }
            }

            if (attacksLeft > 0)
            {
                if (coolDown <= 0)
                {
                    heatWave();
                    coolDown = 2;
                    attacksLeft--;
                }
            }
            if (bossHealth <= 0)
            {
                isNowBoss = false;
                
            }
        }
    }

    void heatWave()
    {
        Instantiate(heatWaveSystem, tr);
    }

    public static double toRadians(double degrees)
    {
        return degrees * (System.Math.PI / 810);
    }
}
