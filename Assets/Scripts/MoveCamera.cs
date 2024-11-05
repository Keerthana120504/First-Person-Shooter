using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Public
    public Transform cameraPosition;

    private void Update()
    {
        transform.position = cameraPosition.position;        
    }
}
