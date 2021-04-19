using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMachine : MonoBehaviour
{
    private static TweenMachine instance;
    private List<Tween> _activeTweens = new List<Tween>();
    private Dictionary<EasingType, Func<float, float>> easingCombiner = new Dictionary<EasingType, Func<float, float>>();
    public bool CanDelete;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            this.enabled = false;
            Debug.LogWarning("there may only be one object with the tweenmachine class");
            return;
        }

        //function V
        easingCombiner.Add(EasingType.easeInSine, Easings.EaseInSine);
        easingCombiner.Add(EasingType.easeOutSine, Easings.EaseOutSine);
        easingCombiner.Add(EasingType.easeInOutSine, Easings.EaseInOutSine);

        easingCombiner.Add(EasingType.easeInCubic, Easings.EaseInCubic);
        easingCombiner.Add(EasingType.easeOutCubic, Easings.EaseOutCubic);
        easingCombiner.Add(EasingType.easeInOutCubic, Easings.EaseInOutCubic);

        easingCombiner.Add(EasingType.easeInQuint, Easings.EaseInQuint);
        easingCombiner.Add(EasingType.easeOutQuint, Easings.EaseOutQuint);
        easingCombiner.Add(EasingType.easeInOutQuint, Easings.EaseInOutQuint);

        easingCombiner.Add(EasingType.easeInCirc, Easings.EaseInCirc);
        easingCombiner.Add(EasingType.easeOutCirc, Easings.EaseOutCirc);
        easingCombiner.Add(EasingType.easeInOutCirc, Easings.EaseInOutCirc);

        easingCombiner.Add(EasingType.easeInElastic, Easings.EaseInElastic);
        easingCombiner.Add(EasingType.easeOutElastic, Easings.EaseOutElastic);
        easingCombiner.Add(EasingType.easeInOutElastic, Easings.EaseInOutElastic);

        easingCombiner.Add(EasingType.easeInQuad, Easings.EaseInQuad);
        easingCombiner.Add(EasingType.easeOutQuad, Easings.EaseOutQuad);
        easingCombiner.Add(EasingType.easeInOutQuad, Easings.EaseInOutQuad);

        easingCombiner.Add(EasingType.easeInQuart, Easings.EaseInQuart);
        easingCombiner.Add(EasingType.easeOutQuart, Easings.EaseOutQuart);
        easingCombiner.Add(EasingType.easeInOutQuart, Easings.EaseInOutQuart);

        easingCombiner.Add(EasingType.easeInExpo, Easings.EaseInExpo);
        easingCombiner.Add(EasingType.easeOutExpo, Easings.EaseOutExpo);
        easingCombiner.Add(EasingType.easeInOutExpo, Easings.EaseInOutExpo);

        easingCombiner.Add(EasingType.easeInBack, Easings.EaseInBack);
        easingCombiner.Add(EasingType.easeOutBack, Easings.EaseOutBack);
        easingCombiner.Add(EasingType.easeInOutBack, Easings.EaseInOutBack);

        easingCombiner.Add(EasingType.easeInBounce, Easings.EaseInBounce);
        easingCombiner.Add(EasingType.easeOutBounce, Easings.EaseOutBounce);
        easingCombiner.Add(EasingType.easeInOutBounce, Easings.EaseInOutBounce);

    }
    private void Update()
    {
        if (_activeTweens.Count < 1) return;

        for (int i = 0; i < _activeTweens.Count; i++)
        {
            _activeTweens[i].UpdateTween(Time.deltaTime);

            if(_activeTweens[i].IsFinished())
            {
                CanDelete = true;
                _activeTweens.RemoveAt(i);
                i -= 1;
                Debug.Log("finished Tween!");
            }
        }
    }

    public void MoveGameObject(GameObject objectToMove, Vector3 targetPosition, float speed, EasingType type)
    {
        Debug.Log(type);
        TweenPosition newTween = new TweenPosition(objectToMove, targetPosition, speed, easingCombiner[type]);
        _activeTweens.Add(newTween);
    }

    public void RotateGameObject(GameObject objectRotate, Vector3 targetRotation, float RotationSpeed, EasingType type)
    {
        Debug.Log(type);
        TweenRotate newTween = new TweenRotate(objectRotate, targetRotation, RotationSpeed, easingCombiner[type]);
        _activeTweens.Add(newTween);
    }
    public void ScaleGameObject(GameObject objectScale, Vector3 targetScale, float ScaleSpeed, EasingType type)
    {
        Debug.Log(type);
        TweenScale newTween = new TweenScale(objectScale, targetScale, ScaleSpeed, easingCombiner[type]);
        _activeTweens.Add(newTween);
    }


    public static TweenMachine GetInstance()
    {
        return instance;
    }
}
