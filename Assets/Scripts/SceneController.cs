﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    WanderCamera camControl;

    public enum STAGE
    {
        SELF_ROT_MIRRORS, MIRROR_N_WIREFRAME, ALIGNED_MIRRORS, BIG_PRISM, LACC
    }

    //For showing stage info on inspector
    public string currentStage;

    STAGE stage;
    public STAGE Stage
    {
        get
        {
            return stage;
        }

        set
        {
            stage = value;
            SwtichStage((int)value);
        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        camControl = Camera.main.GetComponent<WanderCamera>();

        SwtichStage(4);
        //Invoke("StartStage",0.1f);
    }


    private void Update()
    {
        currentStage = stage.ToString();
    }

    private void SwtichStage(int targetStage)
    {
        //resets
        ExitLACC();
        Color normalWorldColor = Color.white;
        Color bigPrismWorldColor = Color.black;
        MirrorManager.instance.UseBugFixValueInShader(false);

        switch (targetStage)
        {
            //just mirrors
            case 0:
                //mirrors
                MirrorManager.mirrorContainer.gameObject.SetActive(true);
                MirrorManager.instance.SetSelfRotate(true);
                MirrorManager.wireframeCubeContainer.gameObject.SetActive(false);
                MainPrism.main.gameObject.SetActive(false);
                MirrorManager.instance.SetMirrorSize(0.8f);
                EnvController.instance.SetWorldColor(normalWorldColor);
                camControl.SwitchMode(WanderCamera.MODE.NORMAL);
                MirrorManager.instance.UseBugFixValueInShader(true);
                break;

            //smaller mirror and wireframe
            case 1:
                //mirror
                MirrorManager.mirrorContainer.gameObject.SetActive(true);
                MirrorManager.instance.SetSelfRotate(true);
                //wireframe cube
                MirrorManager.wireframeCubeContainer.gameObject.SetActive(true);
                //big prism
                MainPrism.main.gameObject.SetActive(false);

                MirrorManager.instance.SetMirrorSize(0.2f);
                EnvController.instance.SetWorldColor(normalWorldColor);
                camControl.SwitchMode(WanderCamera.MODE.NORMAL);

                break;

            // mirror only but no self rotating
            case 2:
                //mirror
                MirrorManager.instance.UseBugFixValueInShader(true);
                MirrorManager.mirrorContainer.gameObject.SetActive(true);
                MirrorManager.instance.SetSelfRotate(false);
                //wireframe cube
                MirrorManager.wireframeCubeContainer.gameObject.SetActive(false);
                //big prism
                MainPrism.main.gameObject.SetActive(false);

                MirrorManager.instance.SetMirrorSize(0.6f);
                camControl.SwitchMode(WanderCamera.MODE.NORMAL);
                EnvController.instance.SetWorldColor(normalWorldColor);
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
                EnvController.instance.SetWorldColor(bigPrismWorldColor);
                camControl.SwitchMode(WanderCamera.MODE.BIG_PRISM);
                break;

            case 4:
                //mirror
                MirrorManager.mirrorContainer.gameObject.SetActive(true);
                MirrorManager.instance.SetSelfRotate(false);
                //wireframe cube
                MirrorManager.wireframeCubeContainer.gameObject.SetActive(false);
                //big prism
                MainPrism.main.gameObject.SetActive(false);
                camControl.SwitchMode(WanderCamera.MODE.LOOK_AT_CENTER_CUBE);
                EnterLACC();
                EnvController.instance.SetWorldColor(normalWorldColor);
                MirrorManager.instance.SetMirrorSize(0.6f);
                break;
        }

    }


    void EnterLACC()
    {
        BoxCollider boxCollider = camControl.gameObject.AddComponent<BoxCollider>();
        boxCollider.size = Vector3.one * 0.1f;
        boxCollider.isTrigger = true;

        boxCollider = MirrorManager.instance.centerCube.gameObject.GetComponent<BoxCollider>();
        boxCollider.enabled = true;
        boxCollider.isTrigger = true;

        MirrorManager.instance.ChangeMirrorsShader(DATA.SHADER_DOUBLE_SIDE);
    }

    void ExitLACC()
    {
        MirrorManager.instance.ChangeMirrorsShader(DATA.SHADER_DEFAULT);

        if (camControl.gameObject.GetComponent<BoxCollider>())
        {
            Destroy(camControl.gameObject.GetComponent<BoxCollider>());
        }

        BoxCollider boxCollider = MirrorManager.instance.centerCube.gameObject.GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
    }

}
