using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
   
     public bool rotateUp;
    public bool rotateDown;
    public bool rotateLeft;
    public bool rotateRight;
    public Transform pivotTransform;
    public float rotateSpeed;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            rotateLeft = true;
        }

        if (rotateUp)
        {
            pivotTransform.Rotate(-(Time.deltaTime * rotateSpeed), 0, 0, Space.Self);
        }
        if (rotateDown)
        {
            pivotTransform.Rotate(Time.deltaTime * rotateSpeed, 0, 0, Space.Self);
        }
        Vector3 pivotRotation = pivotTransform.eulerAngles;
        pivotRotation.x = Mathf.Clamp(pivotRotation.x, -90.0F, 0.0F);
        pivotTransform.eulerAngles = pivotRotation;
        //rotationX = Mathf.Clamp(pivotRotation.eulerAngles.x, -90.0F, 0.0F);
        //pivot.rotation = Quaternion.Euler(rotationX, transform.eulerAngles.y, transform.eulerAngles.z);
        if (rotateLeft)
            pivotTransform.Rotate(0, -(Time.deltaTime * rotateSpeed), 0, Space.World);
        if (rotateRight)
            pivotTransform.Rotate(0, Time.deltaTime * rotateSpeed, 0, Space.World);
    }

}
