using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class ClickGameScript : MonoBehaviour
{
    private int counter;

    public int circleCount = 4;
    public GameObject levelLoader;

    private void Start()
    {
        counter = 0;
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
