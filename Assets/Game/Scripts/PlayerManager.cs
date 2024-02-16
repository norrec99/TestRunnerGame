using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{

    private float playerCurrentScale;

    private void Awake() 
    {
        playerCurrentScale = transform.localScale.x;   
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            IncreasePlayerSize(3, true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            IncreasePlayerSize(10, false);
        }
    }

    private void IncreasePlayerSize(int number, bool isMultiply)
    {
        float increaseScaleAmount = number / 100f;
        if (isMultiply)
        {
            transform.DOScale(Vector3.one * (playerCurrentScale * number), 0.5f);
            playerCurrentScale *= number;
        }
        else
        {
            transform.DOScale(Vector3.one * (playerCurrentScale + increaseScaleAmount), 0.5f);
            playerCurrentScale += increaseScaleAmount;
        }
    }
    private void DecreasePlayerSize(int number, bool isMultiply)
    {
        float decreaseScaleAmount = number / 100f;
        if (isMultiply)
        {
            transform.DOScale(Vector3.one * (playerCurrentScale / number), 0.5f);
            playerCurrentScale /= number;
        }
        else
        {
            transform.DOScale(Vector3.one * (playerCurrentScale - decreaseScaleAmount), 0.5f);
            playerCurrentScale -= decreaseScaleAmount;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Gate"))
        {
            other.transform.parent.GetChild(0).GetComponent<BoxCollider>().enabled = false; // gate 1
            other.transform.parent.GetChild(1).GetComponent<BoxCollider>().enabled = false; // gate 2

            var multiplierGate = other.GetComponent<MultiplierGateController>();

            if (multiplierGate.isMultiply)
            {
                IncreasePlayerSize(multiplierGate.randomNumber, true);
            }
            else
            {
                IncreasePlayerSize(multiplierGate.randomNumber, false);
            }
        }

        if (other.CompareTag("Obstacle"))
        {
            other.GetComponent<BoxCollider>().enabled = false;

            var obstacleObj = other.GetComponent<ObstacleController>();

            if (obstacleObj.isMultiply)
            {
                DecreasePlayerSize(obstacleObj.randomNumber, true);
            }
            else
            {
                DecreasePlayerSize(obstacleObj.randomNumber, false);
            }
        }
    }
}
