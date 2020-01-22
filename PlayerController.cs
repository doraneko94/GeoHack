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
}
