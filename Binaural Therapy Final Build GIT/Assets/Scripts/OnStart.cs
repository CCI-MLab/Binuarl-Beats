using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStart : MonoBehaviour
{
    public GameObject LoadingScreenOnStart;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(PLoad());       


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PLoad()
    {
        yield return new WaitForSecondsRealtime(0.5F);
        LoadingScreenOnStart.active = false;



    }
}
