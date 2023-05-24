using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static InfoTran;


public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void ChooseFrequency(float F)
    {
        InfoTran.pSliderVal = F;
    }
}
