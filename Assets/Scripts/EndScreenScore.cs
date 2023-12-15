using TMPro;
using UnityEngine;

public class EndScreenScore : MonoBehaviour
{
    public TextMeshProUGUI timerLabel, ratingLabel;

    void Start()
    {
        float playerTime = PlayerPrefs.GetFloat("Timer");
        timerLabel.text = (Mathf.Round(playerTime * 100f) / 100f).ToString();
        if (playerTime <= 75f)
            ratingLabel.text += "S+";

    }
}
