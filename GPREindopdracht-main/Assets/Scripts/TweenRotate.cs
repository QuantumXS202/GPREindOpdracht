using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TweenRotate : Tween
{
    private Vector3 _targetRotation;
    protected Vector3 _direction;

    protected override void PerformTween(float easeStep)
    {
        _gameObject.transform.rotation = Quaternion.Euler(_startPosition + (_direction * easeStep));
    }
    protected override void OnTweenComplete()
    {
        _gameObject.transform.rotation = Quaternion.Euler (_targetRotation);
    }

    public TweenRotate(GameObject objectToMove, Vector3 targetRotation, float speed, Func<float, float> easeMethod):base(objectToMove, speed, easeMethod)
    {
        _targetRotation = targetRotation;
        _direction = targetRotation - _gameObject.transform.rotation.eulerAngles;
    }
}
