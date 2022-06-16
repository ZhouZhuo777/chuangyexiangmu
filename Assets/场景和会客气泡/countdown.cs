using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    private Image countDown;
    private float allTime;
    public bool isVictory;
    void Start()
    {
        isVictory = false;
        TryGetComponent(out countDown);
        countDown.fillAmount = 1;
        allTime = 60;
    }

    private float curTime = 0;
    void Update()
    {
        if (countDown.fillAmount != 0 && !isVictory)
        {
            curTime += Time.deltaTime;
            if (curTime >= 1)
            {
                countDown.fillAmount -= 0.02f;
                curTime = 0;
            }
        }
    }
}
