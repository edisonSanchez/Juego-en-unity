using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject caracter;

    // Update is called once per frame
    void Update()
    {
       Vector3 position = transform.position;
       position.x = caracter.transform.position.x;
       transform.position = position;
    }
}
