using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;
using TMPro;

public class UnlimPoss_Mural : MonoBehaviour
{

    public AudioSource builderVoice;

    public string[] instructionLines;
    public string[] lines; // builder dialogue

    public GameObject theInstructions;
    public TextMeshProUGUI displayText; // display text for the instructions
    public TextMeshProUGUI textComponent; // dialogue text
    public GameObject ImReadyButton;
    public GameObject NextButtonActual;

    private int currentInstruction = 0;

    public float textSpeed;
    public int index = 0;

    public GameObject InitiatePanel;
    public GameObject TheParticleSystem;
    public GameObject DialogueBox;
    public GameObject ContinueButton;

    public GameObject cube;
    public VirtualButtonBehaviour Vb;



    void Start()
    {

        theInstructions.SetActive(true);
        displayText.text = instructionLines[currentInstruction];
        NextButtonActual.SetActive(true);
        InitiatePanel.SetActive(false); ;
        DialogueBox.SetActive(false);
        TheParticleSystem.SetActive(true);
        ContinueButton.SetActive(false);
        textComponent.text = string.Empty;

        Vb.RegisterOnButtonPressed(OnButtonPressed);
        //Vb.RegisterOnButtonReleased(OnButtonReleased);

        cube.SetActive(false);
    }

    void Update()
    {
        if (textComponent.text == lines[index]) // advances the text lines
        {
            ContinueButton.SetActive(true);
        }
        if (textComponent.text == lines[6])
        {
            ContinueButton.SetActive(false);
        }

    }
    public void Initiate()
    {
        InitiatePanel.SetActive(false);
        TheParticleSystem.SetActive(false);
        builderVoice.Play();
        DialogueBox.SetActive(true);
        StartCoroutine(TypeLine());

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //public void OnButtonReleased(VirtualButtonBehaviour vb)
    //{
    //    cube.SetActive(false);
    //}

    IEnumerator TypeLine() //types dialogue each letter at a time
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine() // code for the Continue button
    {
        //StopAllCoroutines();
        ContinueButton.SetActive(false);
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            ContinueButton.SetActive(false);
            DialogueBox.SetActive(false);
        }
    }
    public void NextButton()
    {
        currentInstruction++;

        //check it at the end of the array
        if (currentInstruction > instructionLines.Length - 2)
        {
            ImReadyButton.SetActive(true);
            NextButtonActual.SetActive(false);
        }
        displayText.text = instructionLines[currentInstruction];
    }
    public void ImReadyButtonContinue()
    {
        InitiatePanel.SetActive(true);
        theInstructions.SetActive(false);

    }
}
