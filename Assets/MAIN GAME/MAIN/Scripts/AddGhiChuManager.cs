using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddGhiChuManager : MonoBehaviour
{
    [Header("Main Connect")]
    [SerializeField] MainManager MainManager;
    [Header("UI")]
    [SerializeField] TMP_InputField GhiChu;
    private void OnEnable()
    {
        GhiChu.text = "";
    }
    public void Confirm()
    {
        if (!GhiChu.text.Equals(string.Empty))
        {
            MainManager.Pannel_Detail.info.GhiChu.Add(GhiChu.text);
            MainManager.Pannel_Detail.Setup();
            MainManager.Pannel_Detail.Save();
            gameObject.SetActive(false);
        }
    }
    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
