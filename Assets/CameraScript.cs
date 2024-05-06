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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
