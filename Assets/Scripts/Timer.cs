using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    
    private float currentTime;

    private void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("F2");
        PlayerPrefs.SetFloat("Timer", currentTime);
    }

    private void Start()
    {
        currentTime = PlayerPrefs.GetFloat("Timer");
    }
}
