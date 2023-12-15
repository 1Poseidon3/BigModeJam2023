using System.Collections;
using UnityEngine;

public class ClickGameScript : MonoBehaviour
{
    private int counter;
    private ArrayList circles = new();

    public int circleCount = 4;
    public float pulseSpeed = 2f, pulseMagnitude = 0.1f;
    public bool alt = false;
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
            circles.Add(justCreated);
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
                FMODUnity.RuntimeManager.PlayOneShot("event:/MiniGame_Click");
                collider.gameObject.SetActive(false);
                counter++;
            }

        }
        if (alt)
        {
            bool decrease = false;
            foreach (GameObject circle in circles)
            {
                float scaleFactor = 1f + Mathf.Sin(Time.time * pulseSpeed) * pulseMagnitude;
                if (circle.transform.localScale.x >= 2)
                    decrease = true;
                else if (circle.transform.localScale.z <= 0)
                    decrease = false;
                if (decrease)
                    circle.transform.localScale = new Vector3(scaleFactor, scaleFactor, circle.transform.localScale.z);
                else
                    circle.transform.localScale = new Vector3(scaleFactor, scaleFactor, circle.transform.localScale.z);
            }
        }
    }
    
}
