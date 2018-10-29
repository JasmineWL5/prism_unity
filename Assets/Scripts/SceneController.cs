﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
	//create a instance of SceneController so we can call this instance from other places directly
    public static SceneController instance;

    WanderCamera camControl;

	//set a few stages
    public enum STAGE
    {
        MIRRORS, BIG_PRISM
    }

    //For showing stage info on inspector
    //public string currentStage;


//    public STAGE p_stage;

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
    }


    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Stage = SceneController.STAGE.MIRRORS;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Stage = SceneController.STAGE.BIG_PRISM;
		}

    }

    private void SwtichStage(int targetStage)
    {


        switch (targetStage)
        {

		case 0:
			MirrorManager.mirrorContainer.SetActive (true);
			MainPrism.main.gameObject.SetActive (false);
			break;
		case 1:
			MirrorManager.mirrorContainer.SetActive (false);
			MainPrism.main.gameObject.SetActive (true);
			break;
		/*
            //just mirrors
            case 0:
                //mirrors
                MirrorManager.mirrorContainer.gameObject.SetActive(true);
                MirrorManager.instance.SetSelfRotate(true);
                MirrorManager.wireframeCubeContainer.gameObject.SetActive(false);
                MainPrism.main.gameObject.SetActive(false);
                //MirrorManager.instance.SetMirrorSize(DATA.LARGE_MIRROR_SIZE_PERCENTAGE);
//                EnvController.instance.SetWorldColor(normalWorldColor);
                camControl.SwitchMode(WanderCamera.MODE.NORMAL);
                //MirrorManager.instance.UseBugFixValueInShader(true);
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

                //MirrorManager.instance.SetMirrorSize(DATA.SMALL_MIRROR_SIZE_PERCENTAGE);
//                EnvController.instance.SetWorldColor(normalWorldColor);
                camControl.SwitchMode(WanderCamera.MODE.NORMAL);

                break;

            // mirror only but no self rotating
            case 2:
                //mirror
                //MirrorManager.instance.UseBugFixValueInShader(true);
                MirrorManager.mirrorContainer.gameObject.SetActive(true);
                MirrorManager.instance.SetSelfRotate(false);
                //wireframe cube
                MirrorManager.wireframeCubeContainer.gameObject.SetActive(false);
                //big prism
                MainPrism.main.gameObject.SetActive(false);

                //MirrorManager.instance.SetMirrorSize(DATA.MEDIUM_MIRROR_SIZE_PERCENTAGE);
                camControl.SwitchMode(WanderCamera.MODE.NORMAL);
//                EnvController.instance.SetWorldColor(normalWorldColor);
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
//                EnvController.instance.SetWorldColor(bigPrismWorldColor);
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
                break;
			*/
        }

    }


//    void EnterLACC()
//    {
//        BoxCollider boxCollider = camControl.gameObject.AddComponent<BoxCollider>();
//        boxCollider.size = Vector3.one * 0.1f;
//        boxCollider.isTrigger = true;
//
//        boxCollider = MirrorManager.instance.centerCube.gameObject.GetComponent<BoxCollider>();
//        boxCollider.enabled = true;
//        boxCollider.isTrigger = true;
//
//        MirrorManager.instance.ChangeMirrorsShader(DATA.SHADER_DOUBLE_SIDE);
//    }
//
//    void ExitLACC()
//    {
//        MirrorManager.instance.ChangeMirrorsShader(DATA.SHADER_DEFAULT);
//
//        if (camControl.gameObject.GetComponent<BoxCollider>())
//        {
//            Destroy(camControl.gameObject.GetComponent<BoxCollider>());
//        }
//
//        BoxCollider boxCollider = MirrorManager.instance.centerCube.gameObject.GetComponent<BoxCollider>();
//        if (boxCollider != null)
//        {
//            boxCollider.enabled = false;
//        }
//    }

}
