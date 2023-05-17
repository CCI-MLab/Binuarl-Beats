using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//using UnityEngine.Sprite;
using UnityEngine.UI;
using TMPro;

public class ChangeImage : MonoBehaviour
{
    public Image original;
   //public Sprite newSprite;
    Sprite newSprite;
   //private Image ime;
    public TMP_InputField TMP_IF;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
       void SearchForImage()
        {
            var allFiles = Directory.GetFiles("", *.*, SearchOption.AllDirectories);
            foreach (string file in allFiles)
            {
                Debug.Log(file);
            }

        path = Directory.GetCurrentDirectory();        //may come in handy

        path+ "/Builds/SystemMonitor/MultiExeProgram.exe"
            }
    */

    /*
    Image MakeSprite()
    {
        Image im = null;
        im.sprite = Resources.Load<Sprite>("Pictures/Krabs.jpg");
        return im;
    }
    */



    public void ChangeImageMain()
    { 
        string UserInput = TMP_IF.GetComponent<TMP_InputField>().text;
        string removeWhitespace = String.Concat(UserInput.Where(c => Char.IsLetter(c)));
        string toLowerCase = removeWhitespace.ToLower();
        //newSprite = Resources.Load<Sprite>("Pictures/" + UserInput);
        newSprite = Resources.Load<Sprite>("Pictures/" + toLowerCase);
        original.sprite = newSprite;
        if (original.sprite == null)
        {
            Debug.Log("This image does not exist");
        }
        
      
    }




    public void NewImage()
    {
        

    }



}
