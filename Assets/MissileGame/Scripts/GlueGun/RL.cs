using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL : MonoBehaviour
{
    Vector3 direction;
    float speed = 5f;
    float rotSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        direction = other.transform.position;
        if (other.gameObject.tag == "Player")
        {
            //float speed = Vector3.forward * Time.deltaTime;
            transform.position = Vector3.MoveTowards(other.transform.position, direction, speed * Time.deltaTime);
            var rot = Quaternion.LookRotation(direction - other.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotSpeed * Time.deltaTime);
        }

    }
}
