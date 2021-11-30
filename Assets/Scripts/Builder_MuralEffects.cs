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
    public GameObject BuilderDecisionsPanel;
    public GameObject NoiseDecisionPanel;

    public float textSpeed;
    public int index = 0;
    public float decisionTime;
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
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
