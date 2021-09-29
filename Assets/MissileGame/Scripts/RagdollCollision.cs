using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollCollision : MonoBehaviour
{
    //Area Damage
    public float radius = 5f;
    public float Force = 70f;
    [SerializeField] GameObject ExplosionEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider nearbyobject in colliders)
        {
            Rigidbody rb = nearbyobject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward* Force,ForceMode.VelocityChange);
                rb.AddExplosionForce(Force, transform.position, radius);
                rb.AddExplosionForce(Force, transform.position, radius);
                rb.AddExplosionForce(Force, transform.position, radius);
            }
        }

        //foreach (Collider hit in colliders)
        //{
        //    Rigidbody rb = hit.GetComponent<Rigidbody>();
        //    if (rb != null)
        //    {
        //        //rb.AddForce(transform.forward* Force,ForceMode.VelocityChange);
        //        rb.AddExplosionForce(Force, explosionPos, radius, 3.0f);
        //    }
        //}


      
    }
       


}
