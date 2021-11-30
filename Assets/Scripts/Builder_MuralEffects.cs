using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;
using TMPro;

public class Builder_MuralEffects : MonoBehaviour
{
    // audio stuff
    public AudioSource builderVoice;
    public AudioSource clickSoundSource;

    public string[] instructionLines; 
    public string[] lines; // builder dialogue

    public GameObject theInstructions;
    public TextMeshProUGUI displayText; // display text for the instructions
    public TextMeshProUGUI textComponent; // dialogue text
    public GameObject ImReadyButton;
    public GameObject NextButtonActual;

    private int currentInstruction = 0;

    public GameObject TheParticleSystem;
    public GameObject DialogueBox;
    public GameObject ContinueButton;
    public GameObject WhyUnemployedButton;
    public GameObject ContinueNextSceneButton;

    public GameObject InitiatePanel;
    public GameObject DecisionPanel;
    public GameObject DecisionPanel2; // formerly builder decision
    public GameObject DecisionPanel3; // formerly noise decision

    public float textSpeed;
    public int index = 0;
    public float decisionTime;

    public bool closeInstructionsBool = false;
    public bool decisionBool01 = false; // decision panel 1
    public bool decisionBool02 = false; // decision panel 2

    // Start is called before the first frame update
    void Start()
    {
        theInstructions.SetActive(true);
        displayText.text = instructionLines[currentInstruction];
        NextButtonActual.SetActive(true);
        InitiatePanel.SetActive(false);
        DecisionPanel.SetActive(false);
        DialogueBox.SetActive(false);
        DecisionPanel2.SetActive(false);
        TheParticleSystem.SetActive(true);
        ContinueButton.SetActive(false);
        ContinueNextSceneButton.SetActive(false);
        DecisionPanel3.SetActive(false);
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (textComponent.text == lines[index]) // advances the text lines
        {
            ContinueButton.SetActive(true);
        }
        if (textComponent.text == lines[1] && decisionBool01 == false)
        {
            ContinueButton.SetActive(false);
            StartCoroutine(DecisionPopUp());
        }
        if (textComponent.text == lines[5] && decisionBool02 == false)
        {
            ContinueButton.SetActive(false);
            StartCoroutine(DecisionPopUp2());
        }
        if (textComponent.text == lines[19])
        {
            ContinueButton.SetActive(false);
            ContinueNextSceneButton.SetActive(true);
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

    public void NextLine() // code for the Continue button
    {
        //StopAllCoroutines();
        DecisionPanel.SetActive(false);
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

    IEnumerator TypeLine() //types dialogue each letter at a time
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    public void ImReadyButtonContinue()
    {
        InitiatePanel.SetActive(true);
        theInstructions.SetActive(false);

    }
    public void Initiate()
    {
        InitiatePanel.SetActive(false);
        TheParticleSystem.SetActive(false);
        builderVoice.Play();
        DialogueBox.SetActive(true);
        StartCoroutine(TypeLine());

    }

    public void TellBuilder()
    {
        decisionBool01 = true;
        DecisionPanel.SetActive(false);
        ContinueButton.SetActive(false);
        if (index < lines.Length - 1 && decisionBool01 == true)
        {
            index = 2;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    public void WhatYouDo4Living() 
    // same as "so the problem will be solved very soon"
    {
        decisionBool01 = true;
        decisionBool02 = true;
        DecisionPanel.SetActive(false);
        DecisionPanel2.SetActive(false);
        ContinueButton.SetActive(false);
        if (index < lines.Length - 1 && decisionBool01 == true)
        {
            index = 11;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    public void WhyUnemployed()
    {
        decisionBool02 = true;
        DecisionPanel2.SetActive(false);
        ContinueButton.SetActive(false);
        if (index < lines.Length - 1 && decisionBool01 == true)
        {
            index = 6;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator DecisionPopUp() // first decision
    {
        ContinueButton.SetActive(false);
        DecisionPanel.SetActive(true);
        decisionBool01 = true;
        yield return new WaitForSeconds(decisionTime);
    }

    IEnumerator DecisionPopUp2()
    {
        ContinueButton.SetActive(false);
        DecisionPanel2.SetActive(true);
        decisionBool02 = true;
        yield return new WaitForSeconds(decisionTime);
    }
}
