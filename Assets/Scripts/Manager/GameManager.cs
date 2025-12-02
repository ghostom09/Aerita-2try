using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
        void Awake()
        {
            if (null == Instance)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
        }

        void Start()
        {
            Player_Data loaded = Save_Manager.Instance.Load();
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
