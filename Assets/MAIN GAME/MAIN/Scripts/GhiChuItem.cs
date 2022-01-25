using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhiChuItem : MonoBehaviour
{
    [Header("Main Connect")]
    public MainManager MainManager;
    [Header("Info")]
    public string ghichu;
    [Header("UI")]
    [Space(5)]
    public Text GhiChu;
    public void SetUp()
    {
        GhiChu.text = ghichu;
    }
    public void Delete()
    {
        MainManager.Pannel_ConfirmDelete.ShowConfirm(() =>
        {
            MainManager.Pannel_Detail.info.GhiChu.RemoveAll(s => s == ghichu);
            MainManager.Pannel_Detail.Setup();
            MainManager.Pannel_Detail.Save();
        });
    }

}
