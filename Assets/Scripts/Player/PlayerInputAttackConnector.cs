using UnityEngine;

public class PlayerInputAttackConnector : MonoBehaviour
{
    [SerializeField] private Player_Input input;
    [SerializeField] private Player_Attack attack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Connect()
    {
        input.attack += attack.Attack;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) Connect();
    }
}
