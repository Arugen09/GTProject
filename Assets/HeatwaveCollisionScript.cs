using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatwaveCollisionScript : MonoBehaviour
{
    public PlayerBehaviour pb;
    public int damageAmount = 2;
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
        if (string.Equals(other.name, "Player"))
        {
            pb.currentHealth -= damageAmount;
        }
    }
}
