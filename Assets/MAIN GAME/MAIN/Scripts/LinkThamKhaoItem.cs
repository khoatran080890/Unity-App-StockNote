using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LinkThamKhaoItem : MonoBehaviour
{
    [Header("Main Connect")]
    public MainManager MainManager;
    [Header("Info")]
    public string LinkThamKhao;
    [Header("UI")]
    [Space(5)]
    [SerializeField] TextMeshProUGUI linkthamkhao;
    public void SetUp()
    {
        linkthamkhao.text = LinkThamKhao;
    }
    public void ShowLink()
    {
        Application.OpenURL(LinkThamKhao);
    }
    public void Delete()
    {
        MainManager.Pannel_ConfirmDelete.ShowConfirm(() =>
        {
            MainManager.Pannel_Detail.info.LinkThamKhao.RemoveAll(s => s == LinkThamKhao);
            MainManager.Pannel_Detail.Setup();
            MainManager.Pannel_Detail.Save();
        });
    }
}
