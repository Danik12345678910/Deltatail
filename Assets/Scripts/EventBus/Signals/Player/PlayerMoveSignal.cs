using UnityEngine;

public class PlayerMoveSignal : GetValueSignal<PlayerMoveData>
{
    public PlayerMoveSignal(PlayerMoveData value) : base(value)
    {
    }
}