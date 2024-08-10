using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FrameRateSettingsUI : MonoBehaviour
{
    public Slider frameRateSlider;
    public TextMeshProUGUI frameRateText;
    private FrameRateLimitter frameRateLimitter;

    void Start()
    {
        frameRateLimitter = FindObjectOfType<FrameRateLimitter>();
        frameRateSlider.onValueChanged.AddListener(OnSliderValueChanged);
        frameRateSlider.wholeNumbers = true;
        frameRateSlider.minValue = 0;
        frameRateSlider.maxValue = 5;

        // Initialize the slider to the current frame rate limit
        frameRateSlider.value = FrameRateEnumToSliderValue(frameRateLimitter.limit);
        UpdateFrameRateText(frameRateSlider.value);
    }

    void OnSliderValueChanged(float value)
    {
        FrameRateLimitter.FPSLimits newLimit = SliderValueToFrameRateEnum((int)value);
        frameRateText.text = newLimit.ToString().Replace("_", "");
        frameRateLimitter.SetFrameRateLimit(newLimit);
    }

    private int FrameRateEnumToSliderValue(FrameRateLimitter.FPSLimits limit)
    {
        switch (limit)
        {
            case FrameRateLimitter.FPSLimits.Unlimited: return 0;
            case FrameRateLimitter.FPSLimits._30: return 1;
            case FrameRateLimitter.FPSLimits._60: return 2;
            case FrameRateLimitter.FPSLimits._120: return 3;
            case FrameRateLimitter.FPSLimits._240: return 4;
            case FrameRateLimitter.FPSLimits.VSync: return 5;
            default: return 0;
        }
    }

    private FrameRateLimitter.FPSLimits SliderValueToFrameRateEnum(int value)
    {
        switch (value)
        {
            case 0: return FrameRateLimitter.FPSLimits.Unlimited;
            case 1: return FrameRateLimitter.FPSLimits._30;
            case 2: return FrameRateLimitter.FPSLimits._60;
            case 3: return FrameRateLimitter.FPSLimits._120;
            case 4: return FrameRateLimitter.FPSLimits._240;
            case 5: return FrameRateLimitter.FPSLimits.VSync;
            default: return FrameRateLimitter.FPSLimits.Unlimited;
        }
    }

    private void UpdateFrameRateText(float value)
    {
        FrameRateLimitter.FPSLimits newLimit = SliderValueToFrameRateEnum((int)value);
        frameRateText.text = newLimit.ToString().Replace("_", "");
        frameRateLimitter.SetFrameRateLimit(newLimit);
    }
}
