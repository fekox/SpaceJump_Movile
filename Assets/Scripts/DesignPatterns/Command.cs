using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceCommand
{
    void Execute();
}

public class MoveCommand : InterfaceCommand
{
    private readonly PlayerMove player;

    public MoveCommand(PlayerMove player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.StartMoveTouch();
    }
}
public class JumpCommand : InterfaceCommand
{
    private readonly PlayerJump player;

    public JumpCommand(PlayerJump player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.StartJump();
    }
}
