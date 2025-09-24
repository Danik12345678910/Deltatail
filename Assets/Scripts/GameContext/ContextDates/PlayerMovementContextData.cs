using UnityEngine;

public class PlayerMovementContextData : GameContextData<Vector2>
{
    public PlayerMovementContextData(Vector2 playerPosition) : base(playerPosition) { }
}
