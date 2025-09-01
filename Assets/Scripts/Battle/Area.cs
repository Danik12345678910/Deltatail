using UnityEngine;
using System;
using TMPro;

[RequireComponent(typeof(SpriteRenderer))]
public class Area : MonoBehaviourService
{
    private Transform _transform;
    private AreaData _currentData;
    private Bounds _bounds;

    public override Type ServiceType => typeof(Area);


    private void Awake()
    {
        _bounds = GetComponent<SpriteRenderer>().bounds;
        _transform = transform;
        SetPosition(_currentData.Position);
        SetSize(_currentData.Size);
    }

    public Vector2 GetArenaPoint(Horizontal horizontal, Vertical vertical)
    {
        Vector2 point = _bounds.center;

        if(horizontal != Horizontal.Center)
            point.x = horizontal == Horizontal.Right ? _bounds.max.x : _bounds.min.x;
        if(vertical != Vertical.Center)
            point.y = vertical == Vertical.Up ? _bounds.max.y : _bounds.min.y;

        return point;
    }

    public void SetSize(Vector2 newSize)
    {
        _transform.localScale = newSize;
    }

    public void SetPosition(Vector2 position)
    {
        _transform.position = position;
    }

}

public enum Horizontal { Left, Right, Center }
public enum Vertical { Up, Down, Center }
