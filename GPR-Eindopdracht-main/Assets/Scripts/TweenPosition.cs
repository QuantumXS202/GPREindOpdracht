using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TweenPosition : Tween
{
    private Vector3 _targetPosition;
    protected Vector3 _direction;
    protected override void PerformTween(float easeStep)
    {
        _gameObject.transform.position = _startPosition + (_direction * easeStep);
        Debug.Log("BEWEGING!");
    }
    protected override void OnTweenComplete()
    {
        _gameObject.transform.position = _targetPosition;
    }

    public TweenPosition(GameObject objectToMove, Vector3 targetPosition, float speed, Func<float, float> easeMethod) : base(objectToMove, speed, easeMethod)
    {
        _targetPosition = targetPosition;
        _direction = targetPosition - _startPosition;
    }
}
