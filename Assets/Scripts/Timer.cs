using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float currentTime;

    public TextMeshProUGUI timerText;

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
