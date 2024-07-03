using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pauseText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // Set the time scale to 1 to start the game
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale != 0)
            {
                Time.timeScale = 0; // Set the time scale to 0 to pause the game
                pauseText.gameObject.SetActive(true);
                Debug.Log("Game Paused");
            }
            else
            {
                Time.timeScale = 1;
                pauseText.gameObject.SetActive(false);
                Debug.Log("Game Unpaused");
            }
        }
    }
}
