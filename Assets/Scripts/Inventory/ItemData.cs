using UnityEngine;

public class ItemData : ScriptableObject
{
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field : SerializeReference, SubclassSelector] public IItemAction ItemAction { get; private set; } 
}
