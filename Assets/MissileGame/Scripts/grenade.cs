using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
    bool hasExploaded = false;
    public float radius=5f;
    public float Force = 100f;
    [SerializeField] ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (hasExploaded == false)
        {
            Explode();
            hasExploaded = true;
            Instantiate(particle, transform.position, Quaternion.identity);
        }
    }
    private void Explode()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider nearbyobject in colliders)
        {
            Rigidbody rb = nearbyobject.GetComponent<Rigidbody>();
            if (rb != null)
            { 
                rb.AddExplosionForce(Force, transform.position, radius);
            }
        }
    }
}
