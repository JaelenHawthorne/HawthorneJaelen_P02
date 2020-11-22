using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTween : MonoBehaviour
{

    public AnimationCurve curve;
    public float duration;
    public float delay;
    public LeanTweenType easeType;


    private void clicked()
    {
        LeanTween.moveX(gameObject, -259, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
