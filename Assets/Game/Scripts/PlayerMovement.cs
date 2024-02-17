using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float limitValue;
    [SerializeField] private float playerSpeed;

    private Vector3 mouseStartPos;
    private Vector3 playerStartPos;
    private bool moveByTouch;
    private Camera mainCamera;

    private void Awake() 
    {
        mainCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
    }
    private void MoveThePlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {     
            moveByTouch = true;
       
            var plane = new Plane(Vector3.up, 0f);

            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (plane.Raycast(ray,out var distance))
            {
                mouseStartPos = ray.GetPoint(distance + 10f);
                playerStartPos = playerTransform.localPosition;
            }
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            moveByTouch = false;
        }
        
        if (moveByTouch)
        { 
            var plane = new Plane(Vector3.up, 0f);
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (plane.Raycast(ray,out var distance))
            {
                var mousePos = ray.GetPoint(distance +  10f);
                   
                var move = mousePos - mouseStartPos;
                   
                var control = playerStartPos + move;


                control.x = Mathf.Clamp(control.x, -limitValue, limitValue);

                playerTransform.localPosition = new Vector3(Mathf.Lerp(playerTransform.localPosition.x,control.x,Time.deltaTime * playerSpeed)
                    ,playerTransform.localPosition.y,playerTransform.localPosition.z);                  
            }
        }
    }
}
