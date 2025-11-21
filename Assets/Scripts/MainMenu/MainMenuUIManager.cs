using UnityEngine;
using System.Collections.Generic;

public enum UIName
{
    SettingUI,
    SaveUI,
    QuitUI,
}

public enum SettingUI
{
    Graphic,
    Sound,
    Game,
    Keyboard
}
public class MainMenuUIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject settingUI;
    [SerializeField] private GameObject saveUI;
    [SerializeField] private GameObject quitUI;
    
    [Header("Settings")]
    [SerializeField] private GameObject graphic;
    [SerializeField] private GameObject sound;
    [SerializeField] private GameObject keyboard;
    [SerializeField] private GameObject game;
    public void UI(UIName uiName)
    {
        switch (uiName)
        {
            case UIName.SettingUI:
                MainMenu();
                settingUI.SetActive(true);
                break;
            case UIName.SaveUI:
                MainMenu();
                saveUI.SetActive(true);
                break;
            case UIName.QuitUI:
                MainMenu();
                quitUI.SetActive(true);
                break;
        }
    }
    public void Setting(SettingUI settingUIName)
    {
        switch (settingUIName)
        {
            case SettingUI.Graphic:
                SettingQuit();
                graphic.SetActive(true);
                break;
            case SettingUI.Sound:
                SettingQuit();
                sound.SetActive(true);
                break;
            case SettingUI.Game:
                SettingQuit();
                game.SetActive(true);
                break;
            case SettingUI.Keyboard:
                SettingQuit();
                keyboard.SetActive(true);
                break;
        }
    }

    public void SettingQuit()
    {
        graphic.SetActive(false);
        keyboard.SetActive(false);
        game.SetActive(false);
        sound.SetActive(false);
    }

    public void MainMenu()
    {
        settingUI.SetActive(false);
        saveUI.SetActive(false);
        quitUI.SetActive(false);
    }
}
