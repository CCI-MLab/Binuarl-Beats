using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using static InfoTran;


public class HoldColor : MonoBehaviour
{
    public bool isImage = true;
    static int timesIMRan = 0;
    static int timesFreqRan = 0;


    public void GrayOutSelf(string ButtonName)      
    {
        
        Button interactiButton = GameObject.Find(ButtonName).GetComponent<Button>();    //Finds the button
        interactiButton.GetComponent<Image>().color = new Color(200,200,200);             //This is the hexadecimal code for the grey usally used in the pressed button
/*       
        if(isImage == true)
        {
            if (timesIMRan == 1){GrayinIM();}
            InfoTran.PressedDownImage = ButtonName;
            timesIMRan++;
        }
        else
        {
            if(timesFreqRan== 1) { GrayinFreq();}
            InfoTran.PressedDownFreq = ButtonName;
            timesFreqRan++;
        }
*/
    }

    
    void GrayinIM()
    {
        Button interactiButton = GameObject.Find(InfoTran.PressedDownImage).GetComponent<Button>();    //Finds the button
        interactiButton.GetComponent<Image>().color = new Color(255, 255, 255);
    }

    void GrayinFreq()                                                                                                       //These lines both change the image back to the original colors
    {
        Button interactiButton = GameObject.Find(InfoTran.PressedDownFreq).GetComponent<Button>();    //Finds the button
        interactiButton.GetComponent<Image>().color = new Color(255, 255, 255);
    }

    public void SetIsImageToFalse()
    {
        isImage = false;
    }

}
