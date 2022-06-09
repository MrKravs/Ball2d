using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;

    public void ShowSettingsPanel()
    {
        _settingsPanel.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        _settingsPanel.SetActive(false);
    }
}
