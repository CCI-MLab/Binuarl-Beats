using System;
using System.IO;
using System.Collections;
using UnityEngine.Video;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using static InfoTran;



public class ComputerChoice : MonoBehaviour
{
    public Button Display;
    public VideoPlayer videoPlayer;
    public AudioSource Sound;
    public AudioSource Bsource1; 
    public AudioSource Bsource2;
    public AudioSource BKGmusic;
    int PicChoice = -1;
    int RandoMusicChoice;
    // Start is called before the first frame update



    int RandomPic()
    {   PicChoice = Random.Range(0,4);
        return PicChoice; 
    }

    int RandomRelatedMusic()
    {
        int numberOfFiles = Resources.LoadAll("Sound/" + InfoTran.ListAccesor).Length;//ADDED
        return Random.Range(1, numberOfFiles);//ADDED
        //CHANGED(same thing but doesnt work for folders anymore)
        /*
        if (PicChoice == 1 || PicChoice == 2)//treefrog        
            return Random.Range(1, 3);//return Random.Range(6, 7);      
        else if (PicChoice == 3 || PicChoice == 4)//lofi       
            return Random.Range(4, 8);
        else if (PicChoice >= 5 && PicChoice <= 8)//night concert
            return Random.Range(9, 10);
        else if (PicChoice >= 9 && PicChoice <= 12)//rain
            return Random.Range(11, 13);
        else if (PicChoice >= 13 && PicChoice <= 16)//river
            return Random.Range(14, 15);
        else
            return Random.Range(1, 3);
        */
    }

    string RandomBackgroundMusic()
    {
        RandoMusicChoice= Random.Range(1, 5);
        return "bkg" + RandoMusicChoice;
    }
            

    void PlayBeatsRandomized()
    {
        Bsource1.Play();
        Bsource2.pitch = 1.002F;
        Bsource2.Play();
    }

    void Start()
    {
        RandomPic();
        VideoClip myClip = Resources.Load<VideoClip>($"Videos/{PicChoice}");
        videoPlayer.clip = myClip;
        videoPlayer.Play();
        Sound.clip = Resources.Load<AudioClip>($"Sound/{RandomRelatedMusic()}");
        BKGmusic.clip = Resources.Load<AudioClip>($"Sound/{RandomBackgroundMusic()}");
        Sound.Play();
        BKGmusic.Play();
        PlayBeatsRandomized();
    }

    public void SetBeatDifference()
    {
        Bsource1.pitch = InfoTran.pSliderVal;
    }

}
