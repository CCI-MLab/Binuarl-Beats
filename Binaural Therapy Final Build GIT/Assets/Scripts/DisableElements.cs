using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisableElements : MonoBehaviour
{
    public TMP_Text DisplayedText;
    public Button button1;
    public Button button2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeState()
    {
        if (DisplayedText.enabled == true)
        {
            DisplayedText.enabled = false;
            button1.enabled = false;
            button2.enabled = false;
        }
        else
        {
            DisplayedText.enabled = true;
            button1.enabled = true;
            button2.enabled = true;
        }



    }
}
