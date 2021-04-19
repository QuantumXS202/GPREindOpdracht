using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTester : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 targetRotation;
    public Vector3 targetScale;
    public float speed;
    public GameObject Machine;
    public bool OneDone;
    public bool TwoDone;
    public bool ThreeDone;

    public EasingType methodType; // gebruikt de enum list

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            TweenMachine.GetInstance().MoveGameObject(gameObject, targetPosition, speed, methodType);

        
        if (Input.GetKeyDown(KeyCode.Alpha2))
            TweenMachine.GetInstance().RotateGameObject(gameObject, targetRotation, speed, methodType);


        if (Input.GetKeyDown(KeyCode.Alpha3))
            TweenMachine.GetInstance().ScaleGameObject(gameObject, targetScale, speed, methodType);


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OneDone = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TwoDone = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ThreeDone = true;
        }

        if(OneDone && TwoDone && ThreeDone == true)
        {
            if (Machine.GetComponent<TweenMachine>().CanDelete == true)
            {
                Destroy(Machine);
            }
        }
    }
}
