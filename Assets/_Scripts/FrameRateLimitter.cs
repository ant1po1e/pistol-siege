using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HutongGames.PlayMaker.Actions;

public class FrameRateLimitter : MonoBehaviour
{
    public enum FPSLimits
    {
        Unlimited = 0,
        _30 = 30,
        _60 = 60,
        _120 = 120,
        _240 = 240,
        VSync = -1
    }

    public Toggle toggleFPSCounter;
    public FPSLimits limit;
    public TMP_Text fpsText;
    private float deltaTime = 0.0f;

    void Awake()
    {
        ApplyFrameRateLimit();
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString() + " FPS";

        fpsText.enabled = toggleFPSCounter.isOn ? true : false;

    }

    public void SetFrameRateLimit(FPSLimits newLimit)
    {
        limit = newLimit;
        ApplyFrameRateLimit();
    }

    private void ApplyFrameRateLimit()
    {
        if (limit == FPSLimits.VSync)
        {
            QualitySettings.vSyncCount = 1;
            Application.targetFrameRate = -1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = (int)limit;
        }
    }

    public string GetFrameRateLabel()
    {
        switch (limit)
        {
            case FPSLimits.Unlimited:
                return "Unlimited";
            case FPSLimits._30:
                return "30";
            case FPSLimits._60:
                return "60";
            case FPSLimits._120:
                return "120";
            case FPSLimits._240:
                return "240";
            case FPSLimits.VSync:
                return "VSync";
            default:
                return "Unlimited";
        }
    }
}
