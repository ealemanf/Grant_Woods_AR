using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Arrays : MonoBehaviour
{
// using this video as reference: https://www.youtube.com/watch?v=MkjVU5F1it0

    // setting up text fields
    public Text displayText;

    // setting up arrays
    public string[] story = {"test"};

    private int currentItem = 0;
    // Start is called before the first frame update
    void Start()
    {
        displayText.text = story[currentItem];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
