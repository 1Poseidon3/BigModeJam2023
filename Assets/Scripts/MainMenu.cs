using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject levelLoader;

    private void Start()
    {
        PlayerPrefs.SetFloat("Timer", 0.00f);
    }

    public void OnQuitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnStartClick()
    {

        LevelLoader lls = levelLoader.GetComponent<LevelLoader>();
        lls.LoadNextLevel();

        FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_UI_Click");
    }

}
