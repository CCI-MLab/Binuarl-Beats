using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pulse : MonoBehaviour
{
    public GameObject toAnimate;
    Animator toAnimateAnimation;

    void Start()
    {
        toAnimateAnimation = toAnimate.GetComponent<Animator>();
    }

    public void ChangeAnimation()
    {
         toAnimateAnimation.speed = 1.0F;
        // toAnimateAnimation.Play();
    }


}


 

