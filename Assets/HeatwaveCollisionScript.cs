using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatwaveCollisionScript : MonoBehaviour
{
    public PlayerBehaviour pb;
    // Start is called before the first frame update
    void Start()
    {
        pb = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        print(other.name);
        if (string.Equals(other.name, "Player"))
        {
            pb.currentHealth -= 2;
        }
    }
}
