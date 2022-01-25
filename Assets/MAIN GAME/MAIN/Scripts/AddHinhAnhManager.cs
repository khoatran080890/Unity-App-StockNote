using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddHinhAnhManager : MonoBehaviour
{
    [Header("Main Connect")]
    [SerializeField] MainManager MainManager;
    [Header("UI")]
    [SerializeField] TMP_InputField HinhAnh;
    private void OnEnable()
    {
        HinhAnh.text = "";
    }
    public void Confirm()
    {
        if (!HinhAnh.text.Equals(string.Empty))
        {
            MainManager.Pannel_Detail.info.HinhAnh.Add(HinhAnh.text);
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
