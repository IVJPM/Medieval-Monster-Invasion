using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class MainMenuScript : MonoBehaviour
{
    [SerializeField] Button backButton;
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button controlsButton;

    [SerializeField] TextMeshProUGUI movementControls;
    [SerializeField] TextMeshProUGUI actionControls;
   
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void ControlsButton()
    {
        backButton.gameObject.SetActive(true);
        movementControls.gameObject.SetActive(true);
        actionControls.gameObject.SetActive(true);

        controlsButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    public void BackButton()
    {
        backButton.gameObject.SetActive(false);
        movementControls.gameObject.SetActive(false);
        actionControls.gameObject.SetActive(false);

        controlsButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }
}
