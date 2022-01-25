using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddLinkThamKhaoManager : MonoBehaviour
{
    [Header("Main Connect")]
    [SerializeField] MainManager MainManager;
    [Header("UI")]
    [SerializeField] TMP_InputField LinkThamKhao;
    private void OnEnable()
    {
        LinkThamKhao.text = "";
    }
    public void Confirm()
    {
        if (!LinkThamKhao.text.Equals(string.Empty))
        {
            MainManager.Pannel_Detail.info.LinkThamKhao.Add(LinkThamKhao.text);
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
