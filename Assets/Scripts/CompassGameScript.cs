using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompassGameScript : MonoBehaviour
{
    private float angle, timer = 0.0f;
    private bool newDirectionChosen = false;
    private GameObject arrow;
    private Vector3 mousePos, dir;
    private Directions direction;

    private enum Directions
    {
        N,
        E,
        S,
        W
    }

    public float rotationSpeed = 7.0f;
    public bool stageTwo = false, alt = false;
    public TextMeshProUGUI startLabel;
    public GameObject levelLoader;

    void Start()
    {
        arrow = GameObject.FindWithTag("Arrow");
        switch (Random.Range(0, 3))
        {
            case 0:
                direction = Directions.N;
                startLabel.text += "NORTH";
                break;
            case 1:
                direction = Directions.E;
                startLabel.text += "EAST";
                break;
            case 2:
                direction = Directions.S;
                startLabel.text += "SOUTH";
                break;
            case 3:
                direction = Directions.W;
                startLabel.text += "WEST";
                break;
        }
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        dir = mousePos - arrow.transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (alt)
            arrow.transform.rotation = Quaternion.Lerp(arrow.transform.rotation, Quaternion.AngleAxis(angle - 180f, Vector3.forward), rotationSpeed * Time.deltaTime);
        else
            arrow.transform.rotation = Quaternion.Lerp(arrow.transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed * Time.deltaTime);
        if (CheckWinCon((int)arrow.transform.rotation.eulerAngles.z, direction))
        {
            timer += Time.deltaTime;
            if (timer >= 1.5f && !stageTwo)
            {
                LevelLoader lls = levelLoader.GetComponent<LevelLoader>();
                lls.LoadNextLevel();
            }
            else if (timer >= 1.5f && stageTwo)
            {
                if (!newDirectionChosen)
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            direction = Directions.N;
                            startLabel.text = "SPIN THE ARROW\r\nTO THE NORTH";
                            break;
                        case 1:
                            direction = Directions.E;
                            startLabel.text = "SPIN THE ARROW\r\nTO THE EAST";
                            break;
                        case 2:
                            direction = Directions.S;
                            startLabel.text = "SPIN THE ARROW\r\nTO THE SOUTH";
                            break;
                        case 3:
                            direction = Directions.W;
                            startLabel.text = "SPIN THE ARROW\r\nTO THE WEST";
                            break;
                    }
                    GameObject startTextLabel = GameObject.FindWithTag("Starting Text");
                    startTextLabel.SetActive(false);
                    startTextLabel.SetActive(true);
                    timer = 0;
                    newDirectionChosen = true;
                }
                if (timer >= 1.5f)
                {
                    LevelLoader lls = levelLoader.GetComponent<LevelLoader>();
                    lls.LoadNextLevel();
                }
            }
        }
    }

    private bool CheckWinCon(int rot, Directions dir)
    {
        if (rot >= 84 && rot <= 96 && dir == Directions.N)
            return true;
        else if (rot >= 174 && rot <= 186 && dir == Directions.W)
            return true;
        else if (rot >= 264 && rot <= 276 && dir == Directions.S)
            return true;
        else if (((rot >= 354 && rot <= 360) || (rot >= 0 && rot <= 6)) && dir == Directions.E)
            return true;
        else
            timer = 0.0f;
        return false;
    }
}
