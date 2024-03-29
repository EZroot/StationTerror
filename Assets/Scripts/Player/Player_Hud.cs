﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player_Hud : MonoBehaviourPun
{
    public TextMeshProUGUI imposterHudText;
    public TextMeshProUGUI nameHudText;
    public TextMeshProUGUI staminaHudText;
    public TextMeshProUGUI oxygenHudText;
    public TextMeshProUGUI temperatureHudText;
    public TextMeshProUGUI identifyHudText;
    public TextMeshProUGUI progressBar;
    public TextMeshProUGUI taskHudText;
    public TextMeshProUGUI batteryHudText;
    public TextMeshProUGUI healthHudText;

    //defeat/victory
    public GameObject victoryScreen;
    public TextMeshProUGUI victoryScreenWhoWonHudText;
    public TextMeshProUGUI victoryScreenReadyUpHudText;
    public GameObject defeatScreen;
    public TextMeshProUGUI defeatScreenWhoWonHudText;
    public TextMeshProUGUI defeatScreenReadyUpHudText;

    public GameObject minimapImg;

    public Image progressBarBackground;
    public Image progressBarFill;

    Player_Config config;

    private void Start()
    {
        config = GetComponent<Player_Config>();
    }

    public void SetNameText(string text)
    {
        nameHudText.text = text;
    }

    public void SetStaminaText(string text)
    {
        staminaHudText.text = text;
    }

    public void SetOxygenText(string text)
    {
        oxygenHudText.text = text;
    }

    public void SetTemperatureText(string text)
    {
        temperatureHudText.text = text;
    }

    public void SetImposterText(string text)
    {
        imposterHudText.text = text;
    }

    public void SetIdentityText(string text)
    {
        identifyHudText.text = text;
    }

    public void SetProgressBarText(string text)
    {
        progressBar.text = text;
    }

    public void SetTaskText(string text)
    {
        taskHudText.text = text;
    }

    public void SetBatteryHudText(string text)
    {
        batteryHudText.text = text;
    }

    public void SetHealthHudText(string text)
    {
        healthHudText.text = text;
    }

    public void MinimapOn()
    {
        minimapImg.SetActive(true);
    }

    public void MinimapOff()
    {
        minimapImg.SetActive(false);
    }

    public void SetProgressBarOff()
    {
        progressBarBackground.enabled = false;
        progressBarFill.enabled = false;
    }

    public void SetProgressBarOn()
    {
        progressBarBackground.enabled = true;
        progressBarFill.enabled = true;
    }

    public void SetProgressBarFillAmount(float amount)
    {
        progressBarFill.fillAmount = amount;
    }

    [PunRPC]
    public void SetPlayersReadyHudText(int playersReady, int viewId)
    {
        if (photonView.ViewID != viewId)
            return;
        victoryScreenReadyUpHudText.text = "Players Ready: " + playersReady + "/" + CrewManager.Instance.playerPhotonViews.Count;
        defeatScreenReadyUpHudText.text = "Players Ready: " + playersReady + "/" + CrewManager.Instance.playerPhotonViews.Count;
    }

    [PunRPC]
    public void OpenVictoryScreen(int viewId, bool open)
    {
        if (photonView.ViewID != viewId)
            return;
        if (victoryScreen.activeSelf)
            return;
        victoryScreen.SetActive(open);
        config.ShowCursor();
    }

    [PunRPC]
    public void OpenDefeatScreen(int viewId, bool open)
    {
        if (photonView.ViewID != viewId)
            return;
        if (defeatScreen.activeSelf)
            return;
        defeatScreen.SetActive(open);
        config.ShowCursor();
    }
    /* Gotta send multiple people (array), or think of some clever solution
    [PunRPC]
    public void SetWhoWonHudText(int playersReady, int viewId)
    {
        if (photonView.ViewID != viewId)
            return;
        victoryScreenReadyUpHudText.text = "Players Ready: " + playersReady + "/" + CrewManager.Instance.playerPhotonViews.Count;
        defeatScreenReadyUpHudText.text = "Players Ready: " + playersReady + "/" + CrewManager.Instance.playerPhotonViews.Count;
    }*/
}
