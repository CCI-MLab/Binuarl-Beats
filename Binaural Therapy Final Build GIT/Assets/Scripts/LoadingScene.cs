
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using static InfoTran;

public class LoadingScene : MonoBehaviour
{
    public float LoadingMinTime = .05f;
    public GameObject LoadingScreen;
    private float StartLoadingTime;
    private AsyncOperation LoadingOperation;
    public AudioSource ButtonSounds;
    public TextMeshProUGUI text;
    private bool loading = false;
    
    void update()
    {
        if (loading)
        {
            float loadingTime = Time.time - StartLoadingTime;

            // Checks if the min loading time has passed
            if (loadingTime >= LoadingMinTime)
            {
                // At this point if the loading is really over, the scene will load
                // If the load it's not over, it will continue to load and switch to the scene at the end
                LoadingOperation.allowSceneActivation = true;
                loading = false;
            }
        }
    }



     public void LoadScene(int sceneId)
     {
         StartCoroutine(LoadSceneAsync(sceneId));

         StartCoroutine(TextLoading());
     }
    
    public void StartLoading(int sceneId)
    {
        LoadingScreen.SetActive(true);
        LoadTextLoadingScreen();
        // Start loading the Scene asynchronously
        LoadingOperation = SceneManager.LoadSceneAsync(sceneId);

        // Set allowSceneActivation to false inmediately so it wold finish loading
        LoadingOperation.allowSceneActivation = false;

        // Store the starting time of the loading process
        StartLoadingTime = Time.time;

        loading = true;
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
        yield return new WaitForSecondsRealtime(0.2F);
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
