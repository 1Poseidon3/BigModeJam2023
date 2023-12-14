using System.IO;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TypingGameLogic : MonoBehaviour
{
    string[] words;

    public int minimumWordLength = 1, maximumWordLength = 50;
    public bool alt = false;
    public TextMeshProUGUI label;
    public TMP_InputField inputField;
    public GameObject levelLoader;

    void Start()
    {
        words = Resources.Load<TextAsset>("words_alpha").text.Split(new char[] { '\r', '\n' } , System.StringSplitOptions.RemoveEmptyEntries).ToArray();
        label.text = ChooseRandomWord(minimumWordLength, maximumWordLength);
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    private void OnInputValueChanged(string arg0)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/MiniGame_Type");
        if (!alt)
        {
            if (string.Equals(inputField.text, label.text, System.StringComparison.OrdinalIgnoreCase))
            {
                LevelLoader lls = levelLoader.GetComponent<LevelLoader>();
                lls.LoadNextLevel();
            }
            for (int i = 0; i < inputField.text.Length; i++)
            {
                if (!char.ToUpper(inputField.text.ToCharArray()[i]).Equals(char.ToUpper(label.text.ToCharArray()[i])))
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            if (string.Equals(inputField.text, new string(label.text.Reverse().ToArray()), System.StringComparison.OrdinalIgnoreCase))
            {
                LevelLoader lls = levelLoader.GetComponent<LevelLoader>();
                lls.LoadNextLevel();
            }
            for (int i = 0; i < inputField.text.Length; i++)
            {
                if (!char.ToUpper(inputField.text.ToCharArray()[i]).Equals(char.ToUpper(label.text.ToCharArray()[label.text.Length - 1 - i])))
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private string ChooseRandomWord(int lengthMin, int lengthMax)
    {
        string word = words[Random.Range(0, words.Length)];
        if (word.Length < lengthMin || word.Length > lengthMax)
            return ChooseRandomWord(lengthMin, lengthMax);
        return word;
    }
}
