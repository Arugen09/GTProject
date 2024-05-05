using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScrit : MonoBehaviour
{
    public RectTransform tr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = new Vector3(GameObject.Find("Player").GetComponent<Transform>().position.x, GameObject.Find("Player").GetComponent<Transform>().position.y, 90f);
    }
}
