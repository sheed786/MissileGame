using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    [SerializeField] float missileSpeed = 1f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] GameObject Missile;
    float angle;
    Animator anim;

    //CachedReferences (if any)
    Rigidbody rb;

    //States

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
     
       // angle = Mathf.Clamp(angle, -70f, 70f);
        Moving();
    }

    void Moving()
    {
        //For the boat to keep moving Forward
        var mSpeed = missileSpeed * Time.fixedDeltaTime;
        rb.velocity = transform.forward * mSpeed;

        float horizontalInput = Input.GetAxisRaw("Horizontal") * missileSpeed * Time.deltaTime;
        //transform.localRotation = Quaternion.Euler(0, 0, angle);
        //transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);


        

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("Left", true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("Right", true);
        }
        else
        {
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
        }
        Vector3 movementDirection = new Vector3(horizontalInput,0 , 0); //Saving a variable Vector3 Movement to use those axis values for rotation on click
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -40, 40), Mathf.Clamp(transform.position.y, -110, 20),transform.position.z);
        if(transform.localPosition.x >= 40f ||  transform.localPosition.x <= -40f)
        {
            transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            //transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, rotationSpeed*Time.deltaTime);
            // Destroy(gameObject);
        }
        if (transform.localPosition.y >= 20f || transform.localPosition.y <= -110f)
        {
            transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            //  Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        //Destroy(gameObject, 0.5f);
        Missile.SetActive(false);

        if (collision.gameObject.tag == "Enemy")
        {
            //Destroy(gameObject,0.35f);
            Missile.SetActive(false);
        }
    }
}
