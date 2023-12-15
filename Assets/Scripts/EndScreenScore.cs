using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EndScreenScore : MonoBehaviour
{
    public TextMeshProUGUI timerLabel, ratingLabel;
    public Animator transition;
    public float timeToTransitionToMainMenu = 15f;

    void Start()
    {
        float playerTime = PlayerPrefs.GetFloat("Timer");
        timerLabel.text = (Mathf.Round(playerTime * 100f) / 100f).ToString();
        StartCoroutine(backToMainMenu(timeToTransitionToMainMenu));
        if (playerTime <= 75f)
        {
            ratingLabel.text += "S+";
            return;
        }
        else if (playerTime <= 90)
        {
            ratingLabel.text += "S";
            return;
        }
        else if (playerTime <= 110)
        {
            ratingLabel.text += "A";
            return;
        }
        else if (playerTime <= 140)
        {
            ratingLabel.text += "B";
            return;
        }
        else if (playerTime <= 180)
        {
            ratingLabel.text += "C";
            return;
        }
        else
        {
            ratingLabel.text += "D";
            return;
        }
    }

    private IEnumerator backToMainMenu(float delay)
    {
        yield return new WaitForSeconds(delay);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
