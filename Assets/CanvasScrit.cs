using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScrit : MonoBehaviour
{
    public RectTransform tr;
    public Transform objectToFollow;
    public float offsetUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        tr.position = new Vector3(objectToFollow.position.x, objectToFollow.position.y, offsetUp);
    }
}
