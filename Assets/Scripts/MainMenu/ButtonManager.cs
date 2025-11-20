using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private MainMenuUIManager uIManager;
    public void StartGame()
    {
        SceneManagement.instance.LoadScene(SceneName.Ghotom);
    }
    public void QuitGame()
    {
        GameManager.instance.QuitGame();
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