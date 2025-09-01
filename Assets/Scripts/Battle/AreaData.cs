using UnityEngine;

[CreateAssetMenu(fileName = "AreaData", menuName = "Scriptable Objects/AreaData")]
public class AreaData : ScriptableObject
{
    [field :SerializeField] public Vector2 Size {  get; private set; }
    [field :SerializeField] public Vector2 Position {  get; private set; }
}