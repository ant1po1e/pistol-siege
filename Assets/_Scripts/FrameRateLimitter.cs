using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FrameRateLimitter : MonoBehaviour
{
    public enum FPSLimits
    {
        Unlimited = 0,
        _30 = 30,
        _60 = 60,
        _120 = 120,
        _240 = 240,
    }

    public FPSLimits limit;
    public TextMeshProUGUI fpsText;
    public bool useVSync;

    private float deltaTime = 0.0f;

    void Awake()
    {
        Application.targetFrameRate = (int)limit;
        QualitySettings.vSyncCount = useVSync ? 1 : 0;
        QualitySettings.SetQualityLevel(5, true); 
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString() + " FPS";
    }
}
