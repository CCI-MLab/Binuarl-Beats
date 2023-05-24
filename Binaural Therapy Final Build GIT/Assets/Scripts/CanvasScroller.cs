using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScroller : MonoBehaviour
{
    int numberOfFiles;
    int ImageUsed;
    public Canvas canvas;
    public Image canvasImage;
  

    // Start is called before the first frame update
    void Start()
    {
        int ImageUsed = 1;
        string LinkToFolder = "Help_Canvas";
        Resources.LoadAll(LinkToFolder);
        numberOfFiles = Resources.LoadAll(LinkToFolder).Length;
        numberOfFiles = numberOfFiles / 2;
        prevPicture();
        Debug.Log("The number of files in this folder is " + numberOfFiles);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextPicture()
    {
        if (ImageUsed < numberOfFiles)       
            ImageUsed++;
        else
            ImageUsed = numberOfFiles;
            //ImageUsed = 1;
        //canvasImage = canvas.GetComponentInChildren<Image>();
        //canvasImage.sprite = Resources.Load<Sprite>($"Help_Canvas/{ImageUsed}");

        canvasImage.sprite = Resources.Load<Sprite>("Help_Canvas/" + ImageUsed);
    }

    public void prevPicture()
    {
        if (ImageUsed > 1)
            ImageUsed--;
        else
            ImageUsed = 1;
            //ImageUsed = numberOfFiles;

        canvasImage.sprite = Resources.Load<Sprite>("Help_Canvas/" + ImageUsed);
    }

}
