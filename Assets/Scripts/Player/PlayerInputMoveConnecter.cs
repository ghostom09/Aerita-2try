using UnityEngine;

public class PlayerInputMoveConnecter : MonoBehaviour
{
    [SerializeField] private Player_Input input;
    [SerializeField] private Player_Move move;

    public void Connect()
    {
        input.onMove += move.SetMove;
        input.jumpStart += move.JumpStart;
        input.jumpEnd += move.JumpEnd;
        // input.onDash += move.Dash;
    }

    public void Disconnect()
    {
        input.onMove -= move.SetMove;
        input.jumpStart -= move.JumpStart;
        input.jumpEnd -= move.JumpEnd;
    }

    void Start()
    {
        Connect();
    }
}
