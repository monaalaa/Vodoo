using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    public static Action GameStarted;

    public void OnClick()
    {
        GameManager.Instance.GameStarted = true;
    }
}
