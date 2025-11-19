using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    
        public GameManager Instance
        {
            get
            {
                if (null == instance)
                {
                    return null;
                }
                return instance;
            }
        }
    
        void Awake()
        {
            if (null == instance)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else Destroy(gameObject);
        }
    
        public void QuitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
    #endif
        }
}
