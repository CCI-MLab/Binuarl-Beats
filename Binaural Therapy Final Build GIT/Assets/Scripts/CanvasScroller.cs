using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScroller : MonoBehaviour
{
    int numberOfFiles;
    int ImageUsed = 0;
    public Canvas canvas;
    public Image canvasImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void GetNumberOfFiles()
    {

        string LinkToFolder = "Help_Canvas";
        Resources.LoadAll(LinkToFolder);
        numberOfFiles = Resources.LoadAll(LinkToFolder).Length;
        Debug.Log("The number of files in this folder is " + numberOfFiles);
    }

    public void nextPicture()
    {

        if (ImageUsed < numberOfFiles)       
            ImageUsed++;
        else
            ImageUsed = 1;
       canvasImage = canvas.GetComponentInChildren<Image>();
       canvasImage.sprite = Resources.Load<Sprite>($"Help_Canvas/{ImageUsed}");

    }

    public void prevPicture()
    {

    }

}
