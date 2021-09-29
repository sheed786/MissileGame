using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] Vector3 moveDir;
    [SerializeField] [Range(0f,1f)]float movefactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }  //very lowest num is called as Mathf.Epsilon in  unity
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;  //tau - 6.28 radian  --> pi *pi =tau
        float SineWave = Mathf.Sin(cycles*tau);
        movefactor = (SineWave - 1f) / 2f; // 1f - positive or negative side movement  && 2f - movement speed reduce value
        Vector3 movedistance = moveDir * movefactor;
        transform.position = startPos + movedistance;
    }
}
