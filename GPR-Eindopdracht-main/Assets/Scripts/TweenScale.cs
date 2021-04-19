using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TweenScale : Tween
{
    private Vector3 _targetScale;
    protected Vector3 _direction;

    protected override void PerformTween(float easeStep)
    {
        _gameObject.transform.localScale = (_startPosition + (_direction * easeStep));
        Debug.Log("Scaling!");
    }
    protected override void OnTweenComplete()
    {
        _gameObject.transform.localScale = (_targetScale);
    }

    public TweenScale(GameObject objectToScale, Vector3 targetScale, float speed, Func<float, float> easeMethod) : base(objectToScale, speed, easeMethod)
    {
        _targetScale = targetScale;
        _direction = targetScale - _gameObject.transform.localScale;
    }
}

