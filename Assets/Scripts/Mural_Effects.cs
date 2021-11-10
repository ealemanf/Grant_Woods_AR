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
    public string[] lines;
    public TextMeshProUGUI textComponent;
    public GameObject Choice01;
    public GameObject Choice02;
    public GameObject Choice03;
    public float textSpeed;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        InitiatePanel.SetActive(true);
        DialogueBox.SetActive(false);
        TheParticleSystem.SetActive(true);
        ContinueButton.SetActive(false);
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(textComponent.text == lines[index])
        {
            ContinueButton.SetActive(true);
        }
    }

    public void Initiate()
    {
        InitiatePanel.SetActive(false);
        TheParticleSystem.SetActive(false);
        DialogueBox.SetActive(true);
        StartCoroutine(TypeLine());

    }

        IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
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

}
