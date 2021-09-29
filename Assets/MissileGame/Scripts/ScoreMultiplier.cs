using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
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
        switch (collision.gameObject.tag)
        {
            case "x1":
                Debug.Log("Score:1");
                break;
            case "x2":
                Debug.Log("Score:2");
                break;
            case "x3":
                Debug.Log("Score:3");
                break;
            case "x4":
                Debug.Log("Score:4");
                break;
        }
    }
}
