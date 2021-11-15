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
    
    public GameObject TheParticleSystem;
    public GameObject DialogueBox;
    public GameObject ContinueButton;
    public GameObject InitiatePanel;
    public GameObject DecisionPanel;
    public GameObject BuilderDecisionsPanel;
    public string[] lines;
    public TextMeshProUGUI textComponent;
    public GameObject Choice01;
    public GameObject Choice02;
    public GameObject Choice03;
    public float textSpeed;
    private int index = 0;
    public float decisionTime;
    public bool closeInstructionsBool = false;
    public bool decisionBool01 = false;
    public bool decisionBool02 = false;
    public bool decisionBool03 = false;
    public bool decisionBool04 = false;
    public bool decisionBool05 = false;

    // Start is called before the first frame update
    void Start()
    {
        InitiatePanel.SetActive(true);
        DecisionPanel.SetActive(false);
        DialogueBox.SetActive(false);
        BuilderDecisionsPanel.SetActive(false);
        TheParticleSystem.SetActive(true);
        ContinueButton.SetActive(false);
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(textComponent.text == lines[index]) // advances the text lines
        {
            ContinueButton.SetActive(true);
        }
        if(textComponent.text == lines[1] && decisionBool01 == false)
        {
            ContinueButton.SetActive(false);
            StartCoroutine(DecisionPopUp());
        }
        if(textComponent.text == lines[4] && decisionBool02 == false)
        {
            ContinueButton.SetActive(false);
            StartCoroutine(BuilderDecisionPopUp());
        }
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
        foreach(char c in lines[index].ToCharArray())
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
        if (index < lines.Length - 1 && textComponent.text != lines[1] && decisionBool01 == decisionBool02 == decisionBool03 == decisionBool04 == decisionBool05 == false)
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
        else if (index < lines.Length - 1  && decisionBool01 == true)
        {   // continues "How can I help?" branch 
        // lines [2,8]
        // the stuff here may not be needed
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            if (index == 5 && decisionBool02 == true)
            {
                //advance scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        // lines [9,12] you hear that noise
        // lines [13,15] = what do you do for a living and then it transitions to the noise lines
        else
        {
            textComponent.text = string.Empty;
            ContinueButton.SetActive(false);
            //DialogueSystem.SetActive(false);
        }
    }

    IEnumerator DecisionPopUp()
    {
        ContinueButton.SetActive(false);
        DecisionPanel.SetActive(true);
        decisionBool01 = true;
        yield return new WaitForSeconds(decisionTime);       
    }

    public void HowCanHelpButton()
    {   DecisionPanel.SetActive(false);
        //ContinueButton.SetActive(true);
        if (index < lines.Length - 1 && decisionBool01 == true)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    IEnumerator BuilderDecisionPopUp()
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
