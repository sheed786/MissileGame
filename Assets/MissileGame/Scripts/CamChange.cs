using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject Tank;
    // Start is called before the first frame update
    void Start()
    {
        cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cam2.SetActive(true);
            cam1.SetActive(false);
            cam2.transform.parent = Tank.gameObject.transform;
        }
    }
  
}
