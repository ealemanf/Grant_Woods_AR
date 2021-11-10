using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Text_Arrays : MonoBehaviour
{
// using this video as reference: https://www.youtube.com/watch?v=MkjVU5F1it0

    // setting up text fields and Gameobject
    public TextMeshProUGUI displayText;
    public GameObject ImReadyButton;
    public GameObject NextButtonActual;

    // setting up arrays
    public string[] story;
    // = {"In the 1930s, Iowa State University commissioned Grant Wood to create a set of murals on several walls of the old section of the Parks Library. The murals included agrarian, industrial and scientific themes representing different areas of knowledge.",
    //"The paintings were then executed with the help of local Iowan painters, who were chosen by Wood from those he had seen the exhibit at the Iowa State Fair.","Wood sought to represent an American style of painting by using rural subjects. The Library Murals are a perfect representation of the style, honoring the value of work and the American Midwest at a time when the country was falling deeper into the Great Depression",
    //"What you don't know is that these walls whisper and talk to each other during the cold Iowan nights. Today, you will have the chance to listen to their stories."};

    private int currentItem = 0;
    // Start is called before the first frame update
    void Start()
    {
        displayText.text = story[currentItem];
        ImReadyButton.SetActive(false);
    }

    public void NextButton()
    {
        currentItem++;

        //check it at the end of the array
        if (currentItem > story.Length - 2)
        {
            ImReadyButton.SetActive(true);
            NextButtonActual.SetActive(false);
        }
        displayText.text = story[currentItem];
    }

    public void ImReadyButtonContinue(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
