﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Config : MonoBehaviourPun
{
    //Syncing human + mosnter model
    public GameObject[] monsterGraphics;
    public GameObject[] humanGraphics;

    public GameObject humanFPSFists;
    public GameObject humanFPSKnife;
    public GameObject humanFPSPistol;

    public GameObject handHeldKnife;
    public GameObject handHeldPistol;

    public GameObject bloodFX;

    public AudioClip cleaningClip;
    public AudioClip valveSpinClip;
    public AudioClip punchClip;
    public AudioClip punchHitClip;
    public AudioClip shootClip;
    public AudioClip reloadClip;
    public AudioClip knifeClip;

    public AudioSource firstAudioSource;
    public AudioSource secondAudioSource;

    public Animator humanAnimator;
    public Animator monsterAnimator;
    public Animator humanHandsAnimator;
    public Animator monsterHandsAnimator;
    public Animator humanStabAnimator;
    public Animator humanPistolAnimator;
    //Role
    public bool isImposter;
    public bool isEngineer;
    public bool isChemist;
    public bool isBotanist;
    public bool isInvestigator;

    //attack
    public bool canAttack = true;

    //speed
    public int walkSpeed = 2;
    public int runSpeed = 5;

    //Stamina
    public int staminaLevel = 100;
    public int staminaLevelForRecover = 15;

    public Player_CameraShake cameraShake;

    [HideInInspector]
    public float oxygenLevel = 100;
    [HideInInspector]
    public float temperatureLevel = 21;
    [HideInInspector]
    public bool canRun = true;
    [HideInInspector]
    public bool staminaExhausted = false;
    [HideInInspector]
    public float runStamina;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    [PunRPC]
    void PickImposterRPC(int viewID, bool imposter)
    {
        if(viewID==photonView.ViewID)
        {
            isImposter = imposter;

            //Hacked together, needs to be fixed since we should only turn in to a mosnter when the player attacks, and not if hes just imposter
            if (isImposter)
            {
                foreach (GameObject o in monsterGraphics)
                {
                    o.SetActive(true);
                }
                foreach (GameObject o in humanGraphics)
                {
                    o.SetActive(false);
                }
            }
            if (!isImposter)
            {
                foreach (GameObject o in monsterGraphics)
                {
                    o.SetActive(false);
                }
                foreach (GameObject o in humanGraphics)
                {
                    o.SetActive(true);
                }
            }
        }
    }
}
