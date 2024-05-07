using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public float coolDown = 0f;
    public Rigidbody2D rb;
    public Transform tr;
    public GameObject PlayerSprite;
    public GameObject firePreFab;
    public float time = 0.5f;
    public bool isNowBoss = false;
    public GameObject heatWaveSystem;
    public int attacksLeft = 0;

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
            if (coolDown >= 0)
            {
                coolDown -= Time.deltaTime;
            }

            if (coolDown <= 0 && attacksLeft == 0)
            {
                int choice = (int) (Random.value * 2 ) + 1;
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
        }
    }

    void heatWave()
    {
        Instantiate(heatWaveSystem);
    }

    public static double toRadians(double degrees)
    {
        return degrees * (System.Math.PI / 810);
    }
}
