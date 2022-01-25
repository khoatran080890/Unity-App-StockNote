using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HinhAnhItem : MonoBehaviour
{
    [Header("Main Connect")]
    public MainManager MainManager;
    [Header("Info")]
    public string HinhAnh;
    [Header("UI")]
    Image image;
    public void SetUp()
    {
        image = gameObject.GetComponent<Image>();
        GameFunction.Instance.DownloadImage(HinhAnh, image);
    }
    public void Delete()
    {
        MainManager.Pannel_ConfirmDelete.ShowConfirm(() =>
        {
            MainManager.Pannel_Detail.info.HinhAnh.RemoveAll(s => s == HinhAnh);
            MainManager.Pannel_Detail.Setup();
            MainManager.Pannel_Detail.Save();
        });
    }
}
