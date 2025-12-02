using UnityEngine;

public class Data_Manager : MonoBehaviour
{
    private static Data_Manager instance;

    public static Data_Manager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Data_Manager();
            }
            return instance;
        }
    }
}
