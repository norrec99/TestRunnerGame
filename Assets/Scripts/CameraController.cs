using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private Vector3 maxPosition;
    [Range(0,1)]
    [SerializeField] private float progress;

    private void Awake() 
    {
        transform.localPosition = initialPosition;
    }
    void LateUpdate()
    {
        transform.localPosition = Vector3.Lerp(initialPosition, maxPosition, progress);
    }
}
