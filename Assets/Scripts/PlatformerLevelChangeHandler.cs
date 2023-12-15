using UnityEngine;

public class MiniGameLevelLoaderHandler : MonoBehaviour
{
    public GameObject levelLoader;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelLoader lls = levelLoader.GetComponent<LevelLoader>();
            lls.LoadNextLevel();
        }
    }
}
