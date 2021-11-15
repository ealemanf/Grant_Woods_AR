using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueScriptTest : MonoBehaviour
{
    //used this video for reference https://www.youtube.com/watch?v=8oTYabhj248 
    // https://www.youtube.com/watch?v=f-oSXg6_AMQ
    // public Text textComponent;
    public TextMeshProUGUI textComponent;
    public string[] lines; // this is where you put the actual text in Unity
    public float textSpeed;
    private int index = 0;
    public GameObject DialogueSystem;
    public GameObject ContinueButton;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    // Update is called once per frame
    void Update()
    {
        if(textComponent.text == lines[index])
        {
            ContinueButton.SetActive(true);
        }
    }

    // typing each character 1 by 1
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
