using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCameraScript : MonoBehaviour
{
    public GameObject target = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = target.transform.position;
        Vector3 forward = target.transform.forward;
        position.y += 2f;
        position += forward * -7f;
        transform.position = position;

        float arg_new = ArcTan(forward);
        float arg_old = ArcTan(transform.forward);
        transform.Rotate(0f, (arg_new - arg_old) % 360f, 0f);
    }

    float ArcTan(Vector3 forward)
    {
        float f_x = forward.x;
        float f_z = forward.z;
        if (f_z == 0.0) {
            f_z += 1e-7f;
        }
        float arg = Mathf.Atan(f_x / f_z) / (2f * Mathf.PI) * 360f;

        if (f_z < 0 & f_x > 0) arg += 180f;
        if (f_z < 0 & f_x < 0) arg -= 180f;

        return arg;
    }
}
