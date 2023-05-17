using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using static InfoTran;

public class DisplayBuild : MonoBehaviour
{
    public Button Display; 
    public AudioSource soundPlayer;
    public AudioSource Bsource1;
    public AudioSource Bsource2;
    public AudioSource beckSound;
    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()   
    {
        ReadFile();
        Bsource1.pitch = InfoTran.pSliderVal;
    }              

    // Update is called once per frame
    void Update()
    {
    
    }

    public void ReadFile()
    {
        Debug.Log("Testing Debug");
        VideoClip myClip = Resources.Load<VideoClip>($"Videos/{InfoTran.picture}");
        videoPlayer.clip = myClip;
        videoPlayer.Play();
        //    Display.image.sprite = Resources.Load<Sprite>("Images/" + InfoTran.picture);
        /*
        soundPlayer.clip = Resources.Load<AudioClip>($"Sound/{InfoTran.music}");
        Debug.Log(InfoTran.music);
        soundPlayer.Play();
        */


        /*   Moved to Move menu 
        int numberOfFiles = Resources.LoadAll("Sound/"+InfoTran.ListAccesor).Length;//ADDED
        beckSound.clip = Resources.Load<AudioClip>($"Sound/{InfoTran.ListAccesor}/{Random.Range(1, numberOfFiles)}");//CHANGED(Random.Range) 
        beckSound.Play();
        
        */

    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void SetBeatDifference()
    {
        Bsource1.pitch = InfoTran.pSliderVal;
    }

    string RandomBackgroundMusic()
    {
        int RandoMusicChoice = Random.Range(1, 5);
        return "bkg" + RandoMusicChoice;
    }



    /*public void stopUserChoiceStartPrevNext()
    {
        //soundPlayer.Stop();
    }*/



}


/*Helpful Sample Code
using System.IO;

void readTextFile(string file_path)
{
   StreamReader inp_stm = new StreamReader(file_path);

   while(!inp_stm.EndOfStream)
   {
       string inp_ln = inp_stm.ReadLine( );
       // Do Something with the input. 
   }

   inp_stm.Close( );  
}
*/
