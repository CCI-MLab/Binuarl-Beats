using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static InfoTran;



public class SoundControls : MonoBehaviour
{
    public AudioSource ModdedSound;
    public AudioSource soundPlayer;
    public AudioSource Base;
    public Slider intensityGrabber;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
       
    }

    /*
    void CorrectPitchValues(float FromC, float ModdedSubtract)
    {
        float pitch = 0;
        pitch = 1.0f + (FromC * .056f);
        soundPlayer.pitch = pitch;
        ModdedSound.pitch = pitch - ModdedSubtract;
    } */
    /*
    public float GetModdedSubtractAmount(float amount)
    {

        return amount;
    }

    public float GetDistanceFromPitch(float NumberFrom)
    {
        return NumberFrom;
    }
    */
    public void PlayBase()
    {
        Base.Play();
    }

    string [] CheckString(string ToCheck)
    {
        /*
        int runner = 0;
        while (char i != .)
        {
            i = ToCheck[runner];
            runner++;
        }
        */ 
        string[] values = ToCheck.Split(',');
        return values;

    }




    public void GetDesiredBBValue()
    {
       double sliderValue = intensityGrabber.value;
       if(sliderValue < 1 && sliderValue >= .66 )
        {
            InfoTran.pSliderVal = .006f; 
        }

       else if (sliderValue <.66 && sliderValue > .33)
        {
            InfoTran.pSliderVal = .004f;
        }

        else if (sliderValue <= .33)
        {
            InfoTran.pSliderVal = .002f;
        }

       else
        {
            Debug.Log("Binuarl Beats slider out of"); 
        }


    }




    /*
        public void PlayBothSounds(string InputString)
        {
            //InputString = InputString + '!';

            string[] values = CheckString(InputString);
            float[] ConvertValues = Array.ConvertAll(values, s => float.Parse(s));
            float FromC = ConvertValues[0];
            float ModdedSubtract = GetDesiredBBValue(); 
            float pitch;
            pitch = 1.0f + (FromC * .056f);
            soundPlayer.pitch = pitch;
            ModdedSound.pitch = pitch - ModdedSubtract;
          //CorrectPitchValues(FromC, ModdedSubtract);
            soundPlayer.Play();
            ModdedSound.Play();
        }


        public void Stop()
        {
            soundPlayer.Stop();
            ModdedSound.Stop();
            Base.Stop();
        }
        */
}