using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSubject : MonoBehaviour
{
    public event Action Clicked;

    public void ClickButton()
    {
        Clicked?.Invoke();
    }
}
