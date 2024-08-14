using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PauseGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pauseText;
    [SerializeField] Button quitButton;
    [SerializeField] PlayerController playerController;
    [SerializeField] TextMeshProUGUI gameOverText;
 
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // Set the time scale to 1 to start the game
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
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
                quitButton.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                playerController.enabled = false;
            }
            else
            {
                Time.timeScale = 1;
                pauseText.gameObject.SetActive(false);
                Debug.Log("Game Unpaused");
                quitButton.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                playerController.enabled = true;
            }
        }
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
