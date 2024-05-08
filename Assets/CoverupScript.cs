using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverupScript : MonoBehaviour
{
    public PowerPlantBehaviour phscript;
    public Transform tr;
    public Transform tvsTranform;
    public CameraScript camera;
    public bool hasStartedPanning;
    public bool hasFinishedPanning;
    public float time = 0.75f;
    public int repetitions = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (phscript.hasFinishedPanning && !hasStartedPanning)
        {
            camera.panCamera(new Vector3(12.5f, -43.5f, -10f));
            hasStartedPanning = true;
        }

        if (hasStartedPanning && time >= 0f && !hasFinishedPanning)
        {
            time -= Time.deltaTime;
        }

        if (hasStartedPanning && time < 0f && !hasFinishedPanning)
        {
            tr.Translate(new Vector3(1f, 0f, 0f));
            time = 0.75f;
            repetitions += 1;
        }
        if (repetitions == 14)
        {
            tr.localScale = new Vector3(0f, 0f, 0f);
            hasFinishedPanning = true;
            camera.resetCamera();
        }

        
    }
}
