using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private MainMenuUIManager uIManager;
    public void StartGame()
    {
        uIManager.UI(UIName.SaveUI);
    }
    public void QuitGame()
    {
        uIManager.UI(UIName.QuitUI);
    }

    public void QuitYes()
    {
        GameManager.Instance.QuitGame();
    }

    public void QuitNo()
    {
        uIManager.MainMenu();
    }
    
    public void Setting()
    {
        uIManager.UI(UIName.SettingUI);
    }

    public void Graphic()
    {
        uIManager.Setting(SettingUI.Graphic);
    }
    public void Sound()
    {
        uIManager.Setting(SettingUI.Sound);
    }
    public void Keyboard()
    {
        uIManager.Setting(SettingUI.Keyboard);
    }
    public void Game()
    {
        uIManager.Setting(SettingUI.Game);
    }

    public void QuitSetting()
    {
        uIManager.SettingQuit();
        uIManager.MainMenu();
    }
}