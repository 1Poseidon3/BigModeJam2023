using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class ClickGameScript : MonoBehaviour
{
    private int counter;

    public int circleCount = 4;
    public Vector2 spawnAreaSize = new(15f, 10f);
    public GameObject circlePrefab, levelLoader;

    private void Start()
    {
        counter = 0;
        for (int i = 0; i < circleCount; i++)
        {
            GameObject justCreated = Instantiate(circlePrefab, new Vector3(Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2), Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2), 0f), Quaternion.identity);
            float newScale = Random.Range(1.0f, 2.0f);
            justCreated.transform.localScale = new Vector3(newScale, newScale, justCreated.transform.localScale.z);
        }
    }

    private void Update()
    {
        if (counter >= circleCount)
        {
            LevelLoader lls = levelLoader.GetComponent<LevelLoader>();
            lls.LoadNextLevel();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = Physics2D.OverlapPoint(mousePosition);
            if (collider != null && collider.CompareTag("Circle"))
            {
                Debug.Log("Circle clicked");
                collider.gameObject.SetActive(false);
                counter++;
            }
        }
    }
}
