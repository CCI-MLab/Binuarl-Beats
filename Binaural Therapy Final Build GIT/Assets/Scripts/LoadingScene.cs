
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using static InfoTran;

public class LoadingScene : MonoBehaviour
{
    public GameObject LoadingScreen;
    public AudioSource ButtonSounds;
    public TextMeshProUGUI text;
    
    public void LoadScene(int sceneId){
        StartCoroutine(LoadSceneAsync(sceneId));

        StartCoroutine(TextLoading());
    }

    /*public void LoadSceneAsync() 
    {
        StartCoroutine(TextLoading());
    } 
    */

    public void LoadTextLoadingScreen()
    {
        StartCoroutine(TextLoading());
    }

    IEnumerator LoadSceneAsync(int sceneId){

        LoadingScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        yield return null;
    }

    IEnumerator TextLoading()             //Adds movement to the loading screen to be used in going to the animation 
    {                                       //needed due to longer loading times for this setting
        while (true)
        {
            text.text = "Loading.";
            yield return new WaitForSecondsRealtime(0.5F);
            text.text = "Loading..";
            yield return new WaitForSecondsRealtime(0.5F);
            text.text = "Loading...";
            yield return new WaitForSecondsRealtime(0.5F);
        }
    }

    public void ChooseFrequencyAndLoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }



    
    public void ChooseFrequency(float F)
    {
        InfoTran.pSliderVal = F;
    }

    public void PlayButtonSound()    //Added 4/24/23
    {
         ButtonSounds.Play();
    }
    
    public void BuildSceneLoadingScreen()
    {

    }

}
