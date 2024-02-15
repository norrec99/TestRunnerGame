using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private Vector3 initialRotation;

    private void Awake() 
    {
        initialRotation = transform.eulerAngles;    
    }

    void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.transform.position.z);

        transform.eulerAngles = new Vector3(playerTransform.transform.eulerAngles.x + initialRotation.x, playerTransform.transform.eulerAngles.y + initialRotation.y, 0);
    }
}
