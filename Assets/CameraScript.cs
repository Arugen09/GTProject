using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
    public Transform tr;
    public bool isFollowing = true; 
    public bool isInBossRoom = false;
    public Camera c;
    public DeathBehaviourScript deathBehaviour;
    public GameObject backdrop;
    public GameObject landscape;
    public float time = 0.75f;
    public float endStage = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (deathBehaviour.time >= 0)
        {
            backdrop.GetComponent<Transform>().localScale = new Vector3(0f, 0f, 0f);
            landscape.GetComponent<Transform>().localScale = new Vector3(0f, 0f, 0f);
            if (isFollowing)
            {
                c.orthographicSize = 7;
                Transform playerTransform = Player.GetComponent<Transform>();
                tr.position = new Vector3(playerTransform.position.x, playerTransform.position.y, -10f);
            }
            else if (isInBossRoom)
            {
                c.orthographicSize = 13.5F;
                tr.position = new Vector3(-58f, -22.5f, -10f);
            }
        }
        if (deathBehaviour.time <= 0)
        {
            backdrop.GetComponent<Transform>().position = new Vector3(tr.position.x, tr.position.y, 0);
            isInBossRoom = false;
            isFollowing = false;
            if (time >= 0f)
            {
                time -= Time.deltaTime;
                if (endStage == 0)
                {
                    backdrop.GetComponent<Transform>().localScale = new Vector3(25.35f * (13.5f/7f), 14.6f * (13.5f/7f), 0f);
                    backdrop.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, (0.5f - time)/0.5f);
                }
                else if (endStage == 1)
                {
                    backdrop.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, time/3f);
                }
            }
            

            if (time < 0f)
            {
                if (endStage == 0)
                {
                    landscape.GetComponent<Transform>().localScale = new Vector3(0.07f, 0.12f, 0f);
                    endStage = 1;
                    time = 3f;
                }
            }
        }
    }

    public void panCamera(Vector3 target)
    {
        isFollowing = false;
        tr.position = target;
    }

    public void resetCamera()
    {
        isFollowing = true;
    }
}
