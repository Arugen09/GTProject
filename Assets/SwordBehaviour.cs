using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    public Rigidbody2D swordBody;
    public Rigidbody2D playerBody;
    public Collider2D enemyCollider;
    public PlayerBehaviour playerScript;
    public SpriteRenderer sr;
    public Transform swordTransform;
    public float beginningAngle;
    public float middleAngle;
    public float finalAngle;
    public bool isSlashing;
    public bool startSlashing;
    public float time = 0.7f;
    public BossBehaviour bossScript;
    public bool hasTouchedBoss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSlashing)
        {
            if (!startSlashing)
            {
                startSlashing = true;
                swordTransform.localScale = Vector3.one;
            }
            
            if (time >= 0f)
            {
                time -= Time.deltaTime;
            }

            if (time < 0f)
            {
                time = 0.7f;
                isSlashing = false;
            }

            if (time <= 0.7f && time >= 0.5f)
            {
                swordBody.rotation = beginningAngle;
                sr.sprite = Resources.Load<Sprite>("SwordSlashes/swordpowerUP");
            }
            else if (time >= 0.3f)
            {
                //swordBody.rotation = middleAngle;
                sr.sprite = Resources.Load<Sprite>("SwordSlashes/swordslashmid");

            }
            else if (time >= 0f)
            {
                //swordBody.rotation = finalAngle;
                sr.sprite = Resources.Load<Sprite>("SwordSlashes/swordslash");
            }
        }
        else
        {
            swordTransform.localScale = Vector3.zero;
            startSlashing = false;
        }

        swordBody.position = playerBody.position;

        if (swordBody.IsTouching(enemyCollider) && !hasTouchedBoss)
        {
            hasTouchedBoss = true;
            bossScript.bossHealth -= 5;
        }
        else if (!swordBody.IsTouching(enemyCollider))
        {
            hasTouchedBoss = false;
        }
    }
}
