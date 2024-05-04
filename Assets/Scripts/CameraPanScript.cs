using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanScript : MonoBehaviour
{
    public Collider2D trigger;
    public Transform transform;
    private int currentZone = 0;
    private double[] zoneXCoords = new double[] { 1.665 , 13.333 };
    private double[] zoneYCoords = new double[] { 0 , 0 };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        Debug.Log("HELLO!");
        if (GameObject.Find("Player").GetComponent<Rigidbody2D>().position.x < transform.position.x)
        {
            currentZone -= 1;
        }
        else
        {
            currentZone += 1;
            transform.Translate(new Vector3((float)zoneXCoords[currentZone], (float)zoneYCoords[currentZone], 10));
        }
    }
}
