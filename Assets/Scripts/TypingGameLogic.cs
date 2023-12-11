using System.IO;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TypingGameLogic : MonoBehaviour
{
    //string[] words = File.ReadAllLines("Assets/Scripts/words_alpha.txt").SelectMany(word => word.Split(' ', System.StringSplitOptions.RemoveEmptyEntries)).ToArray();
    string[] words;

    [SerializeField]
    int minimumWordLength = 1;
    [SerializeField]
    int maximumWordLength = 50;
    [SerializeField]
    TextMeshProUGUI label;
    [SerializeField]
    TMP_InputField inputField;

    public GameObject levelLoader;

    void Start()
    {
        words = Resources.Load<TextAsset>("words_alpha").text.Split(new char[] { '\r', '\n' } , System.StringSplitOptions.RemoveEmptyEntries).ToArray();
        label.text = ChooseRandomWord(minimumWordLength, maximumWordLength);
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    private void OnInputValueChanged(string arg0)
    {
        if (inputField.text.Equals(label.text))
        {
            LevelLoader lls = levelLoader.GetComponent<LevelLoader>();
            lls.LoadNextLevel();
        }
        for (int i = 0; i < inputField.text.Length; i++)
        {
            if (!inputField.text.ToCharArray()[i].Equals(label.text.ToCharArray()[i]))
            {
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
