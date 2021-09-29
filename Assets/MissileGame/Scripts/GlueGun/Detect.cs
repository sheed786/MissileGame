using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    bool detected;
    public GameObject target;
    public Transform enemy;

    public GameObject bullet;
    public Transform shootPoint;

    public float shootSpeed = 10f;
    public float timetoshoot = 1.3f;
    //public float turnSpeed = 400f;
    float originalTime;
    // Start is called before the first frame update
    void Start()
    {
        originalTime = timetoshoot;
        //var tar = target.transform.position - new Vector3(3, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(detected)
        {
            enemy.LookAt(target.transform);
        }
    }
    private void FixedUpdate()
    {
        if(detected)
        {
            timetoshoot -= Time.deltaTime;

            if(timetoshoot<0)
            {
                ShootPlayer();
                timetoshoot = originalTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            detected = true;
           // target = other.gameObject;
        }
    }

    void ShootPlayer()
    {
        GameObject currentbullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = currentbullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
    }
}
