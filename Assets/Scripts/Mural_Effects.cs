using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;
using TMPro;
public class Mural_Effects : MonoBehaviour
{

    // setting up the visual effects for murals
    public GameObject theInstructions;
    public TextMeshProUGUI displayText; // display text for the instructions
    public GameObject ImReadyButton;
    public GameObject NextButtonActual;
    public string[] instructionLines;
    private int currentInstruction = 0;
    public GameObject TheParticleSystem;
    public GameObject DialogueBox;
    public GameObject ContinueButton;
    public GameObject HowCanButtonLiving; 
    public GameObject ContinueNextSceneButton;
    public GameObject InitiatePanel;
    public GameObject DecisionPanel;
    public GameObject BuilderDecisionsPanel;
    public GameObject NoiseDecisionPanel;
    public string[] lines;
    public TextMeshProUGUI textComponent;
    //public GameObject Choice01;
    //public GameObject Choice02;
    //public GameObject Choice03;
    public float textSpeed;
    public int index = 0;
    public float decisionTime;
    public bool closeInstructionsBool = false;
    public bool decisionBool01 = false; // builder panel 1
    public bool decisionBool02 = false; // builder panel 2
    public bool decisionBool03 = false; // what was that noise panel


    // Start is called before the first frame update
    void Start()
    {
        theInstructions.SetActive(true);
        displayText.text = instructionLines[currentInstruction];
        NextButtonActual.SetActive(true);
        InitiatePanel.SetActive(false);
        DecisionPanel.SetActive(false);
        DialogueBox.SetActive(false);
        BuilderDecisionsPanel.SetActive(false);
        TheParticleSystem.SetActive(true);
        ContinueButton.SetActive(false);
        ContinueNextSceneButton.SetActive(false);
        NoiseDecisionPanel.SetActive(false);
        HowCanButtonLiving.SetActive(false);
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
        if (textComponent.text == lines[4] && decisionBool02 == false)
        {
            ContinueButton.SetActive(false);
            StartCoroutine(BuilderDecisionPopUp());
        }
        if (textComponent.text == lines[12] && decisionBool03 == false)
        {
            ContinueButton.SetActive(false);
            StartCoroutine(NoiseDecisionPopUp());
        }
        if (textComponent.text == lines[8])
        {
            ContinueButton.SetActive(false);
            ContinueNextSceneButton.SetActive(true);
        }
        if (textComponent.text == lines[15])
        {
            ContinueButton.SetActive(false);
            HowCanButtonLiving.SetActive(true);
        }
    }

    IEnumerator NoiseDecisionPopUp()
    {
        ContinueButton.SetActive(false);
        NoiseDecisionPanel.SetActive(true);
        decisionBool03 = true;
        yield return new WaitForSeconds(decisionTime);
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

    public void Initiate()
    {
        InitiatePanel.SetActive(false);
        TheParticleSystem.SetActive(false);
        DialogueBox.SetActive(true);
        StartCoroutine(TypeLine());

    }

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
        DecisionPanel.SetActive(false);
        ContinueButton.SetActive(false);
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        /*
        else if (index < lines.Length - 1 && textComponent.text == lines[1] && decisionBool01 == decisionBool02 == decisionBool03 == decisionBool04 == decisionBool05 == false)
        {
            ContinueButton.SetActive(false);
            StartCoroutine(DecisionPopUp());
        }
        */
        //else if (index < lines.Length - 1 && decisionBool01 == true)
        //{   // continues "How can I help?" branch 
        //    // lines [2,8]
        //    // the stuff here may not be needed
        //    index++;
        //    textComponent.text = string.Empty;
        //    StartCoroutine(TypeLine());
        //}
        //    if (index == 5 && decisionBool02 == true)
        //    {
        //        //advance scene
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //    }
        //}

        //if (textComponent.text == lines[8])
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
        // lines [9,12] you hear that noise
        // lines [13,15] = what do you do for a living and then it transitions to the noise lines
        else
        {
            textComponent.text = string.Empty;
            ContinueButton.SetActive(false);
            DialogueBox.SetActive(false);
        }
    }

    IEnumerator DecisionPopUp() // first decision
    {
        ContinueButton.SetActive(false);
        DecisionPanel.SetActive(true);
        decisionBool01 = true;
        yield return new WaitForSeconds(decisionTime);
    }

    public void HowCanHelpButton() // decision 01 from the first decision popup (DecisionPopUp)
    {   DecisionPanel.SetActive(false);
        ContinueButton.SetActive(false);
        NoiseDecisionPanel.SetActive(false);
        HowCanButtonLiving.SetActive(false);
        //ContinueButton.SetActive(true);
        if (index < lines.Length)
        {
            index = 2;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    IEnumerator BuilderDecisionPopUp() // first decision to talk about the builder
    {
        BuilderDecisionsPanel.SetActive(true);
        decisionBool02 = true;
        yield return new WaitForSeconds(decisionTime);
    }
    public void OkWillFindBuilder()
    {  //advnace to next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        /*BuilderDecisionsPanel.SetActive(false);
                if (index < 5 && decisionBool01 == true)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } 
        */
    }

    public void NotSureBuilder()
    {
        BuilderDecisionsPanel.SetActive(false);
        ContinueButton.SetActive(false);
        if (index < lines.Length - 1 && decisionBool01 == true)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    public void WhatWasThatNoise()
    {
        DecisionPanel.SetActive(false);
        ContinueButton.SetActive(false);
        //ContinueButton.SetActive(true);
        if (index < lines.Length - 1 && decisionBool01 == true)
        {
            index = 9;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

    }

    public void WhatDoYouLiving()
    {
        DecisionPanel.SetActive(false);
        ContinueButton.SetActive(false);
        //ContinueButton.SetActive(true);
        if (index < lines.Length - 1 && decisionBool01 == true)
        {
            index = 13;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

/*
        public void NextLine() // code for the Continue button
    {
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
            //DialogueSystem.SetActive(false);
        }
    }
*/
}
