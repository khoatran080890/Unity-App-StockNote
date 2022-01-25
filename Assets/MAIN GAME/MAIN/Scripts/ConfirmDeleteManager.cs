using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmDeleteManager : MonoBehaviour
{
    Action OK_action;
    Action Exit_action;

    public void ShowConfirm(Action OK_action = null, Action Exit_action = null)
    {
        this.OK_action = OK_action;
        this.Exit_action = Exit_action;
        gameObject.SetActive(true);
    }
    public void OK()
    {
        OK_action?.Invoke();
        gameObject.SetActive(false);
        OK_action = null;
        Exit_action = null;
    }
    public void Exit()
    {
        Exit_action?.Invoke();
        gameObject.SetActive(false);
        OK_action = null;
        Exit_action = null;
    }
}
