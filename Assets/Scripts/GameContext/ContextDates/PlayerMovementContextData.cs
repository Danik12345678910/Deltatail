using UnityEngine;

public class PlayerMovementContextData : GameContextData<PlayerMoveData>
{
    public PlayerMovementContextData(PlayerMoveData playerPosition) : base(playerPosition) { }
}
