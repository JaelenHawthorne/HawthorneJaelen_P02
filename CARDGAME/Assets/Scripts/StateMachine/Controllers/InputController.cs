using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    public event Action PressedConfirm = delegate { };
    public event Action PressedCancel = delegate { };
    public event Action PressedLeft = delegate { };
    public event Action PressedRight = delegate { };

    // Update is called once per frame
    void Update()
    {
        DetectConfirm();
        DetectCancel();
        DetectLeft();
        DetectRight();
    }


    public void DetectRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PressedRight?.Invoke();
        }
    }

    public void DetectLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PressedLeft?.Invoke();
        }
    }

    public void DetectCancel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PressedCancel?.Invoke();
        }
    }

    public void DetectConfirm()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PressedConfirm?.Invoke();
        }
    }
}
