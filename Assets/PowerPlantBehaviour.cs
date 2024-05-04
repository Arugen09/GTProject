using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantBehaviour : MonoBehaviour
{

    public Rigidbody2D rb;

    public ParticleSystem ps;

    public GameObject child;

    public bool hasExploded = false;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform childTransform in this.transform)
        {
            child = childTransform.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        print(child.GetComponent<SpriteRenderer>().sprite.ToString());
        if (child.GetComponent<LeverScript>().hasBeenPressed && !hasExploded)
        {
            Instantiate(ps);
            hasExploded = true;
        }
    }
}
