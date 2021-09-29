using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(0f, 0f, 2f * Time.deltaTime);
    }
}
