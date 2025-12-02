using UnityEngine;

public class Game_Data
{
    public Player_Data Player;
    public Progress_Data Progress;

    public Game_Data()
    {
        Player = new Player_Data();
        Progress = new Progress_Data();         
    }
}