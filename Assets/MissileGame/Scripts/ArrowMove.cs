using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public float ForwSpeed = 1000f;
    public float rotspeed=10f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            MoveForward();
        }
        float x = Input.GetAxis("Horizontal") * rotspeed;
        float y = Input.GetAxis("Vertical") * rotspeed;
        transform.position += (transform.right * x * Time.deltaTime);

        transform.position += (transform.up * y * Time.deltaTime);

    }

  

    private void MoveForward()
    {
        rb.velocity= transform.forward *ForwSpeed* Time.deltaTime;
       

    }
}
