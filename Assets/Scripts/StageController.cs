﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{

    [SerializeField]
    float swtichFreq = 10f;

    public AudioSource StagSwtichingSound;


    public static StageController instance;

    int activeStage;
    WanderCamera camControl;


    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
        camControl = Camera.main.GetComponent<WanderCamera>();
    }

    // Update is called once per frame
    void Update()
    {


    }



    public void SwtichStage(int targetStage)
    {
        switch (targetStage)
        {
            //just mirrors
            case 0:
                //mirrors
                MirrorManager.mirrorContainer.gameObject.SetActive(true);
                MirrorManager.main.SetSelfRotate(true);
                //wireframe cubes
                MirrorManager.wireframeCubeContainer.gameObject.SetActive(false);
                //big prism
                MainPrism.main.gameObject.SetActive(false);

                MirrorManager.main.SetMirrorSize(0.8f);
                camControl.SwitchMode(false);
                break;

            //smaller mirror and wireframe
            case 1:
                //mirror
                MirrorManager.mirrorContainer.gameObject.SetActive(true);
                MirrorManager.main.SetSelfRotate(true);
                //wireframe cube
                MirrorManager.wireframeCubeContainer.gameObject.SetActive(true);
                //big prism
                MainPrism.main.gameObject.SetActive(false);

                MirrorManager.main.SetMirrorSize(0.2f);
                camControl.SwitchMode(false);
                break;

            // mirror only but no self rotating
            case 2:
                //mirror
                MirrorManager.mirrorContainer.gameObject.SetActive(true);
                MirrorManager.main.SetSelfRotate(false);
                //wireframe cube
                MirrorManager.wireframeCubeContainer.gameObject.SetActive(false);
                //big prism
                MainPrism.main.gameObject.SetActive(false);

                MirrorManager.main.SetMirrorSize(0.6f);
                camControl.SwitchMode(false);
                camControl.GoForward(10);
                break;

            //just big prism
            case 3:
                //mirror
                MirrorManager.mirrorContainer.gameObject.SetActive(false);
                //wireframe cube
                MirrorManager.wireframeCubeContainer.gameObject.SetActive(false);
                //big prism
                MainPrism.main.gameObject.SetActive(true);

                camControl.SwitchMode(true);
                break;
        }

    }
}
