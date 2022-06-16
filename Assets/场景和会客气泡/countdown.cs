using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    private Image countDown;
    private float allTime;
    public bool isVictory;
    public bool isFail;

    public GameObject canvas;
    public GameObject victory;
    public GameObject fail;
    void Start()
    {
        isVictory = false;
        isFail = false;
        TryGetComponent(out countDown);
        countDown.fillAmount = 1;
        allTime = 60;
        
        canvas.SetActive(false);
        victory.SetActive(false);
        fail.SetActive(false);
    }

    void ShowFileView()
    {
        canvas.SetActive(true);
        victory.SetActive(false);
        fail.SetActive(true);
    }

    private float curTime = 0;
    void Update()
    {
        if (countDown.fillAmount != 0 && !isVictory && !isFail)
        {
            curTime += Time.deltaTime;
            if (curTime >= 1)
            {
                countDown.fillAmount -= 0.015f;
                if (countDown.fillAmount <= 0)
                {
                    isFail = true;
                    ShowFileView();
                }
                curTime = 0;
            }
        }
    }
}
