using UnityEngine;

public class IntermissionLoader : MonoBehaviour
{
    public GameObject levelLoader;

    void Start()
    {
        LevelLoader lls = levelLoader.GetComponent<LevelLoader>();
        lls.LoadNextLevel();
    }
}
