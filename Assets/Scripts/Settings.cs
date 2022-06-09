using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public readonly static string BGColor_r = nameof(BGColor_r);
    public readonly static string BGColor_g = nameof(BGColor_g);
    public readonly static string BGColor_b = nameof(BGColor_b);

    public readonly static string CircleColor_r = nameof(CircleColor_r);
    public readonly static string CircleColor_g = nameof(CircleColor_g);
    public readonly static string CircleColor_b = nameof(CircleColor_b);

    public readonly static string SoundEnabled = nameof(SoundEnabled);

    public static Settings Instance { get; private set; }

    [SerializeField] private Toggle[] _bgToggles;
    private Dictionary<Color, Toggle> _colorsBG;

    [SerializeField] private Toggle[] _circleColors;
    private Dictionary<Color, Toggle> _colorsCircle;

    public static Color ParseCircleColorFromPP()
    {
        float r = PlayerPrefs.GetFloat(Settings.CircleColor_r);
        float g = PlayerPrefs.GetFloat(Settings.CircleColor_g);
        float b = PlayerPrefs.GetFloat(Settings.CircleColor_b);

        return new Color(r, g, b);
    }

    public static Color ParseBGColorFromPP()
    {
        float r = PlayerPrefs.GetFloat(Settings.BGColor_r);
        float g = PlayerPrefs.GetFloat(Settings.BGColor_g);
        float b = PlayerPrefs.GetFloat(Settings.BGColor_b);

        return new Color(r, g, b);
    }

    public void SetBGColor(Color color)
    {
        PlayerPrefs.SetFloat(BGColor_r, color.r);
        PlayerPrefs.SetFloat(BGColor_g, color.g);
        PlayerPrefs.SetFloat(BGColor_b, color.b);
    }

    public void SetCircleColor(Color color)
    {
        PlayerPrefs.SetFloat(CircleColor_r, color.r);
        PlayerPrefs.SetFloat(CircleColor_g, color.g);
        PlayerPrefs.SetFloat(CircleColor_b, color.b);
    }

    public void SetSoundEnabled(bool value)
    {
        int val = value ? 1 : 0;
        PlayerPrefs.SetInt(SoundEnabled, val);
    }

    private void Awake()
    {
        Instance = this;

        InitBGToggles();
        InitCircleColorToggles();
    }

    private void Start()
    {
        Color savedBGColor = ParseBGColorFromPP();
        _colorsBG[savedBGColor].isOn = true;

        Color savedCircleColor = ParseCircleColorFromPP();
        _colorsCircle[savedCircleColor].isOn = true;
    }

    private void InitBGToggles()
    {
        _colorsBG = new Dictionary<Color, Toggle>();

        foreach (var toggle in _bgToggles)
        {
            toggle.onValueChanged.AddListener(val => BGToggleChangeValueHandler(val, toggle));
            Color bgColor = toggle.GetComponentInChildren<Image>().color;
            _colorsBG.Add(bgColor, toggle);
        }
    }

    private void InitCircleColorToggles()
    {
        _colorsCircle = new Dictionary<Color, Toggle>();

        foreach (var toggle in _circleColors)
        {
            toggle.onValueChanged.AddListener(val => CircleToggleChangeValueHandler(val, toggle));
            Color bgColor = toggle.GetComponentInChildren<Image>().color;
            _colorsCircle.Add(bgColor, toggle);
        }
    }


    private void BGToggleChangeValueHandler(bool value, Toggle sender)
    {
        if (value == false) return;

        Color bgColor = sender.GetComponentInChildren<Image>().color;
        SetBGColor(bgColor);
    }

    private void CircleToggleChangeValueHandler(bool value, Toggle sender)
    {
        if (value == false) return;

        Color color = sender.GetComponentInChildren<Image>().color;
        SetCircleColor(color);
    }
}
