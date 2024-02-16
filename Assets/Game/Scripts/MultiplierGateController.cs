using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplierGateController : MonoBehaviour
{
    public TMP_Text gateNo;
    public int randomNumber;
    public bool isMultiply;
    void Start()
    {
        if (isMultiply)
        {
            randomNumber = Random.Range(1, 3);
            gateNo.text = "X" + randomNumber;
        }
        else
        {
            randomNumber = Random.Range(10, 100);

            if (randomNumber % 2 != 0)
                randomNumber += 1;
            
            gateNo.text = "+" + randomNumber.ToString();
        }
    }
}
