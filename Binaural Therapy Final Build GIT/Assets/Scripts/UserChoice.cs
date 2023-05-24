using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//using UnityEngine.Sprite;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
using static InfoTran;





public class UserChoice : MonoBehaviour
{
    int ImageChoice = -1;
    int AudioSave = -1;
    public Image original;
    public Sprite newSprite;
    public AudioSource soundPlayer;
    //public VideoPlayer videoPlayer;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeImage(int NumberChoice)
    {
        InfoTran.picture = NumberChoice;
        Debug.Log(InfoTran.picture);
        //TakeMusic();

        //ADDED
        //changes folder according to NumberChoice
        if (NumberChoice == 1 || NumberChoice == 2)//treefrog        
            InfoTran.ListAccesor = "Frog";
        else if (NumberChoice == 3 || NumberChoice == 4)//lofi       
            InfoTran.ListAccesor = "LoFi";
        else if (NumberChoice >= 5 && NumberChoice <= 8)//night concert
            InfoTran.ListAccesor = "Night";
        else if (NumberChoice >= 9 && NumberChoice <= 12)//rain
            InfoTran.ListAccesor = "River";
        else if (NumberChoice >= 13 && NumberChoice <= 16)//river
            InfoTran.ListAccesor = "Rain";
        //ADDED
    }

    public void ChangeFileMusicAccess(string UserChoice)
    {
        InfoTran.ListAccesor = UserChoice;
    }


    void ChangeImageMain()
    {
        //newSprite = Resources.Load<Sprite>("Pictures/" + UserInput);
        newSprite = Resources.Load<Sprite>("Images/" + ImageChoice);
        original.sprite = newSprite;
        if (original.sprite == null)
        {
            Debug.Log("This image does not exist");
        }
    }

    /*
    public void PlaySound()
    {

        //soundPlayer = Resources.Load<AudioSource>("Sounds/" + AudioSave);
        soundPlayer.clip = Resources.Load<AudioClip>($"Sound/AudioSave");
        soundPlayer.Play();
    }
    */


    int ChooseNumberFromIndex(int[] number)
    {
        int last = number.Length;
        Random.Range(0, last);
        return number[last];
    }








    /*
    int ChooseNumberFromIndex(int[] number)
    {
        int FirstNumber = number[0];
        int LastNumber = number[number.Length()];
        int toSend = -1;
        bool Runner = true;

        while (Runner)
        {
            randomNumber = Random.Range(FirstNumber, 15);
            
            for(int i = 0;i < number.Length(); i++)
            {
                if (number[i] == Random)
                {
                    Runner = false;
                }
                

            }


        }
        return randomNumber;
    }
    */



    /*

     public void WriteFile()
     {

        using StreamWriter file = new("Assets/TransferInput.txt");
        {
            file.WriteLine($"{ImageChoice} {AudioSave}");
            file.Close();
        }
     }

    public void ReadFile() 
    {
        string readText = File.ReadAllText("Assets/TransferInput.txt");
        string[] myList = readText.Split(' ');
        newSprite = Resources.Load<Sprite>("Images/" + myList[0]);
        original.sprite = newSprite;
        soundPlayer.clip = Resources.Load<AudioClip>($"Sound/{myList[1]}");
        //soundPlayer.clip = 
    }
    */
}


/*
    void TakeMusic()
    {
        if (InfoTran.picture == 1 || InfoTran.picture == 2 || InfoTran.picture == 10 || InfoTran.picture == 11) //Rain
        {
            int[] myNumbers = new int[] { 1, 4, 5 };            //Make sure number to the left is the smallest and right is the biggest
            InfoTran.picture = ChooseNumberFromIndex(myNumbers);
        }
        else if (InfoTran.picture == 9 || InfoTran.picture ==  7 || InfoTran.picture == 8 || InfoTran.picture ==15)        //Night
        {
            InfoTran.music = Random.Range(2, 3);
        }
        else if (InfoTran.picture == 6)                  //Frog   
        {
            InfoTran.music = Random.Range(8,10);
        }                 
        else               
        {
            InfoTran.music = Random.Range(6, 7);
        }
        Debug.Log(InfoTran.music);
    }
    */