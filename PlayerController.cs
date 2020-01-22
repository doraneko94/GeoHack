using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up")) {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("down")) {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("right")) {
            transform.Rotate(0f, speed * Time.deltaTime * 10f, 0f);
        }
        if (Input.GetKey("left")) {
            transform.Rotate(0f, -speed * Time.deltaTime * 10f, 0f);
        }
        if (Input.GetKey(KeyCode.X)) {
            transform.Rotate(speed * Time.deltaTime * 50f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.Z)) {
            transform.Rotate(0f, 0f, speed * Time.deltaTime * 50f);
        }
    }

    Vector3 ForwardXZ(Vector3 forward) {
        float f_x = forward.x;
        float f_z = forward.z;
        float norm = Mathf.Sqrt(f_x * f_x + f_z * f_z);
        Vector3 vec = new Vector3(f_x / norm, 0f, f_z / norm);
        return vec;
    }
}
