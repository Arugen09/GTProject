using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehaviourScript : MonoBehaviour
{
    public BossBehaviour bossBehaviour;
    public bool hasDied;
    public SpriteRenderer sr;

    public float time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bossBehaviour.bossHealth <= 0)
        {
            hasDied = true;
        }

        if (hasDied)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }

            sr.color = new Color(1f, 1f, 1f, time/5f);
        }
    }
}
