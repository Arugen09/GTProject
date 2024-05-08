using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantBehaviour : MonoBehaviour
{

    public Rigidbody2D rb;

    public ParticleSystem ps;

    public GameObject child;

    public Transform tr;

    public bool hasExploded = false;

    public bool hasPannedCamera = false;

    public bool hasFinishedPanning = false;

    public CameraScript camera;

    public ParticleSystem particles;

    public float timeToSee = 9f;

    public SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        int x = 0;
        foreach (Transform childTransform in this.transform)
        {
            if (x == 0)
            {
                child = childTransform.gameObject;
                
            }
            x += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (child.GetComponent<LeverScript>().hasBeenPressed && !hasPannedCamera && !hasExploded)
        {
            camera.panCamera(new Vector3(tr.position.x, tr.position.y, -10f));
            
            hasPannedCamera = true;
        }

        if ((hasPannedCamera || hasExploded) && !hasFinishedPanning)
        {
            timeToSee -= Time.deltaTime;
            sr.color = new Color(255f, 255f, 255f, (255f * (timeToSee / 7f)));
            //tr.localScale = new Vector3(5f, (float)(timeToSee / 7f) * 5f, 1f);
            //tr.position = new Vector3(10f, (tr.localScale.y / 5f) * -39f, 0f);
        }
        
        if (hasPannedCamera && timeToSee <= 7)
        {
            particles = Instantiate(ps, tr.position, Quaternion.identity);
            hasPannedCamera = false;
            hasExploded = true;
        }

        if (hasExploded && timeToSee <= 0)
        {
            hasFinishedPanning = true;
            tr.localScale = new Vector3(0f, 0f, 0f);
        }

        // if (hasExploded && particles.GetComponent<duration)
    }
}
