using System;
using UnityEngine;

public class BattlePlayerController : MonoBehaviourService
{
    public override Type ServiceType => throw new NotImplementedException();
    [field : SerializeField] public GameObject PlayerGameObject { get; private set; }

    private void Awake()
    {
        if(PlayerGameObject == null)
            throw new NullReferenceException($"�������� {PlayerGameObject} �� ��������� ������� �������� � ����������");
    }

    public void Disactivate() => PlayerGameObject.SetActive(false);

    public void Activate() => PlayerGameObject.SetActive(true);
}
