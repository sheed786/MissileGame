using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    Rigidbody rb;
    float Score;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.tag=="Target")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Score++;
            FindObjectOfType<ArrowMove>().enabled = false;
        }
    }
}
