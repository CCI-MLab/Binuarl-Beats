using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LoadOnStart : MonoBehaviour
{
    public AudioSource Sound;
    string[] FolderNames = new string[4]; 
    // Start is called before the first frame update
    void Start()
    {
        FolderNames[0] = "Frog";
        FolderNames[1] = "Night";
        FolderNames[2] = "River";
        FolderNames[3] = "Rain";
        Debug.Log("Folder Populated");
        PreLoadMain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PreLoadMain()
    {
        for(int i = 0; i < FolderNames.Length; i++)
        {
            int numOfFilesInFolder = GetNumberOfFiles(FolderNames[i]);
            StartCoroutine(PlayAllSongsInFolder(FolderNames[i], numOfFilesInFolder));
        }
        SceneManager.LoadScene(0);
    }

    IEnumerator PlayAllSongsInFolder(string folderName, int numOfFilesInFolder)
    {
        for (int j = 0; j < numOfFilesInFolder; j++)
        {
            Sound.clip = Resources.Load<AudioClip>($"Sound/{folderName}/{j}");
            Sound.Play();
            Debug.Log("One round finished");
            yield return new WaitForSecondsRealtime(0.5F);
            
        }
    }   

    int GetNumberOfFiles(string FolderName)
    {                      
        Debug.Log("HI13");
        string LinkToFolder = "Sound/" + InfoTran.ListAccesor;   
        Resources.LoadAll(LinkToFolder);     //Maybe load all is slowing things down?
        return Resources.LoadAll(LinkToFolder).Length;
 ///       Debug.Log("The number of files in this folder is " + numberOfFiles);
    }

}
