using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AR_Scenes : MonoBehaviour
{
    public GameObject theInstructions;
     // setting up text fields and Gameobject
    public TextMeshProUGUI displayText;
    public GameObject ImReadyButton;
    public GameObject NextButtonActual;

    // setting up arrays
    public string[] instructions01;
     //{"Find the first mural. It's called 'When Tillage Begins' and it's located in the first floor in the Grant Wood Mural Lobby behind Bookends Cafe.", "Use your mobile phone and look at the whole mural using our app. What do you see? When you're ready to continue, press 'I'm ready'"};

    // setting up counter
    private int currentItem = 0;


    // Start is called before the first frame update
    void Start()
    {
        theInstructions.SetActive(true);
        displayText.text = instructions01[currentItem];
    }

    public void NextButton()
    {
        currentItem++;

        //check it at the end of the array
        if (currentItem > instructions01.Length - 2)
        {
            ImReadyButton.SetActive(true);
            NextButtonActual.SetActive(false);
        }
        displayText.text = instructions01[currentItem];
    }
        public void ImReadyButtonContinue()
    {
        theInstructions.SetActive(false);
    }

    
}
