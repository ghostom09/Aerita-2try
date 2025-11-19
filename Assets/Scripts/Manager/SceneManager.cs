using UnityEngine;

// public enum SceneName
// {
//     MainMenu,
//     Ingame,
//     Loading,
//     
// }
public class SceneManagement : MonoBehaviour
{
    public static SceneManagement instance { get; private set; }

    public SceneManagement Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        } 
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);
    }

    // public void LoadScene(SceneName scene)
    // {
    //     UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
    // }
}