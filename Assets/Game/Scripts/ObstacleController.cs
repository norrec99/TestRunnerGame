using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ObstacleController : MonoBehaviour
{
    public TMP_Text obstacleNo;
    public int randomNumber;
    public bool isMultiply;
    void Start()
    {
        if (isMultiply)
        {
            randomNumber = Random.Range(1, 3);
            obstacleNo.text = "÷" + randomNumber;
        }
        else
        {
            randomNumber = Random.Range(10, 100);

            if (randomNumber % 2 != 0)
                randomNumber += 1;
            
            obstacleNo.text = "-" + randomNumber.ToString();
        }

        MoveObstacle();
    }

    private void MoveObstacle()
    {
        var sequence = DOTween.Sequence();

        int randomDuration = Random.Range(1, 6);
        
        sequence.Append(transform.DOMoveX(-1.3f, randomDuration).SetEase(Ease.Linear));
        sequence.Append(transform.DOMoveX(1.3f, randomDuration).SetEase(Ease.Linear));
        sequence.SetLoops(int.MaxValue, LoopType.Yoyo);
    }
}
