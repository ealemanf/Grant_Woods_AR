using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ending_Script : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public GameObject NextButtonActual;
    public GameObject StartOverButton;
    public GameObject QuitGameButton;

    public string[] story;

    private int currentItem = 0;
    // Start is called before the first frame update
    void Start()
    {
        displayText.text = story[currentItem];
        StartOverButton.SetActive(false);
        QuitGameButton.SetActive(false);
    }

    public void NextButton()
    {
        currentItem++;

        //check it at the end of the array
        if (currentItem > story.Length - 2)
        {
            NextButtonActual.SetActive(false);
            StartOverButton.SetActive(true);
            QuitGameButton.SetActive(true);
        }
        displayText.text = story[currentItem];
    }

    public void StartOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        // takes user back to the first scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
