using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketUpgrade : MonoBehaviour
{
    [SerializeField] List<GameObject> rockets = new List<GameObject>();
    
    void Start()
    {
        //foreach (GameObject gO in GameObject.FindGameObjectsWithTag("Player"))
        //{
        //    rockets.Add(gO);
        //    var rocketcount = rockets.Count;

        //}
        for (int i = 0; i < rockets.Count; i++)
        {

        }
        
    }
}
