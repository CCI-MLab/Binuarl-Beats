using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Microsoft.VisualBasic;
using static InfoTran;

public class MoveMenu : MonoBehaviour
{
    bool expanded;
    public GameObject toMove;
    public GameObject LoadingScreen;
    public AudioSource Sound;
    int SoundChoice;
    int numberOfFiles;
    int RandomNumber; 
    public Slider VolumeSlider;
    int[] CorrectlyNamedFiles;
    bool ComputerControl = false;             //TURN THIS ON WHEN RUNNING ON A COMPUTER 
    public AudioSource BBeats1;
    public AudioSource BBeats2;
    float timeNow;                            //To measure time taken to switch sounds




    // Start is called before the first frame update
    void Start()
    {
        
        //StartCoroutine(nextSongx3());
        expanded = false;
        if (int.TryParse(InfoTran.ListAccesor, out int number))//ADDED
        {
            if(number < numberOfFiles)    //ADDED
                SoundChoice = number;     //ADDED
        }
        else//ADDED
            SoundChoice = 1;
        GetNumberOfFiles(); //populates numberOfFiles.
        if (ComputerControl == true)
        {                      
            GetNamesOfFiles();
        }
        /*
        for (int i = 1; i <= numberOfFiles; i++)  // loops through each file to load them
        {
            NextSong();
            Debug.Log("Gonna Wait");
       //     Wait(5F);
      //      Sound.Stop();
            StopBeats();
        }*/

        PlayOnStart();
       // LoadingScreen.SetActive(false);

    }

    IEnumerator nextSongx3()
    {
        NextSong();
        yield return new WaitForSecondsRealtime(0.5F); 
        NextSong();
        yield return new WaitForSecondsRealtime(0.5F);
        NextSong();
        yield return new WaitForSecondsRealtime(0.5F);
    }


    IEnumerator Wait(float waitFor)  //M
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(waitFor);
        //After we have waited 5 seconds print the time again.
       // Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }


    // Update is called once per frame
    void Update()
    {
        timeNow = Time.realtimeSinceStartup;
        BBeats1.volume = VolumeSlider.value;
        BBeats2.volume = VolumeSlider.value;


    }

    void GetNumberOfFiles()
    {
 
        string LinkToFolder = "Sound/" + InfoTran.ListAccesor;
        Resources.LoadAll(LinkToFolder);
        numberOfFiles = Resources.LoadAll(LinkToFolder).Length;
        Debug.Log("The number of files in this folder is " + numberOfFiles);
    }

    void GetNamesOfFiles()
    {
        string FolderPath = ("Assets/Resources/Sound/" + InfoTran.ListAccesor);
        var info = new DirectoryInfo(FolderPath);
        var fileInfo = info.GetFiles();
        int max = 0;
        // foreach (FileInfo file in fileInfo) Debug.Log(file);
        int numFilesTotal = 0;
        int evenOrOdd = 1;//ADDED
        foreach (FileInfo file in fileInfo)
        {
            string fileName = file.Name;
            char firstLetter = fileName[0];         //for the demo, each list will hold a maximum of 9 images
            if(char.IsDigit(firstLetter))
            {
                int firstLetterToInt = (int)firstLetter;            //Converts Single letter to integer
                if (firstLetter - 1 == max)
                {
                    max = firstLetterToInt / 2;//CHANGED (/2)
                }
            }
            if(evenOrOdd%2 == 1)//ADDED
                numFilesTotal++;
            evenOrOdd++;//ADDED
        }
        evenOrOdd = 1;//ADDED
        int changing = max;
        int fileWereAt = 1;
        foreach (FileInfo file in fileInfo)
        {
            string filePath = FolderPath + "/" + file.Name;
            int toChange = numFilesTotal - max;
          //  Debug.Log("Detected" + toChange + " to change");
            if (fileWereAt > max)
                for (int i = 1;i <= toChange; i++)
                {
          //          Debug.Log(file.Name);
                    changing++;
   // Caused errors                 AssetDatabase.RenameAsset(filePath, fileWereAt.ToString());               //fileWereAt.ToString;
   //                 AssetDatabase.Refresh();
                }
            if(evenOrOdd%2 == 0)//ADDED
                fileWereAt++;
            evenOrOdd++;//ADDED

        }

        /*
        foreach (FileInfo file in fileInfo)              
        {
         string filePath = FolderPath + "/" + file.Name;
         string fileName = file.Name;
         char firstLetter = fileName[0];
         if(!char.IsDigit(firstLetter))
            {
                max = max + 1;   
               // file.Move(fileName, (max));
               AssetDatabase.RenameAsset(filePath, max.ToString());
               AssetDatabase.Refresh();

            }
            int firstLetterInt = (int)firstLetter;


            Debug.Log("First Letter:" + firstLetter);
        }
        */
        

    }

    public void MoveMenuView(GameObject x)
    {
        Vector3 expand = new Vector3(410, 0, 0);
        Vector3 contract = new Vector3(-410, 0, 0);//346
        toMove = x;

        if (expanded == false)
        {
            x.transform.position += expand;
            expanded = true;
        }
        else if (expanded == true)
        {
            x.transform.position += contract;
            expanded = false;
        }
    }

    int soundChoice()
    {
        return SoundChoice;
    }


    void PlayOnStart()           //Added
    {
        SoundChoice = Random.Range(1, numberOfFiles);         //Added to fix the repeating #2
        Sound.clip = Resources.Load<AudioClip>($"Sound/{InfoTran.ListAccesor}/{SoundChoice}");//CHANGED(Random.Range) 
       // Sound.clip = Resources.Load<AudioClip>($"Sound/{InfoTran.ListAccesor}/2");
        Sound.Play();

    }


    public void NextSong()
    {
        float startTime = Time.realtimeSinceStartup;
        Sound.Stop();
        StopBeats();
        if (SoundChoice < numberOfFiles)   //Changed to make the iterator work for many different kinds of files    
            SoundChoice++;
        else
            SoundChoice = 1;
        Debug.Log($" The SoundChoice is {SoundChoice}");
        Sound.clip = Resources.Load<AudioClip>($"Sound/{InfoTran.ListAccesor}/{soundChoice()}");
        Sound.PlayOneShot(Sound.clip);
        StartBeats();
        Debug.Log($"Time taken is {startTime - timeNow}");
    }
    // Currently, (Loopthrough (line 45) = true && DSP Buffer = best latency

    //First time button on river time (DSP Buffer set to default) : 0.00128s, 0.00134s, 0.00128s
    //First time button on river time (DSP Buffer set to best latency) : 0.00122s, 0.00119s, 0.00121s
    //First time button on river time (DSP Budffer set to best latency && Loopthrough): 0.00113s, 0.00102s, 0.00103s


        public void PreviousSong()
    {
        StopBeats();
        Sound.Stop();
        if (SoundChoice > 1)
            SoundChoice--;
        else
            SoundChoice = numberOfFiles;
        Sound.clip = Resources.Load<AudioClip>($"Sound/{InfoTran.ListAccesor}/{soundChoice()}");
        Sound.Play();
        StartBeats(); 
    }
       

    //Stops and Starts Binaural Beats 

     void StopBeats()
    {
        BBeats1.Pause();
        BBeats2.Pause();
    }

    void StartBeats()
    {
        BBeats1.Play();
        BBeats2.Play();
    }

    
    
    

}


/* Solution
 * 
 * using UnityEditor;

public class FileRenamer : MonoBehaviour
{
    public void RenameFile(string filePath, string newFileName)
    {
        AssetDatabase.RenameAsset(filePath, newFileName);
    }
}
*
*/