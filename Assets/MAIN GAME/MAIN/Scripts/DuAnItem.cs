using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuAnItem : MonoBehaviour
{
    [Header("Main Connect")]
    public MainManager MainManager;
    [Header("Info")]
    public DuAn duan;
    [Header("UI")]
    [Space(5)]
    public Text TenDuAn;
    [Space(5)]
    public Text ViTri;
    [Space(5)]
    public Text TongDienTich;
    [Space(5)]
    public Text ThanhPham;
    public Slider ThanhPham_Slider;
    [Space(5)]
    public Text DaBan;
    public Slider DaBan_Slider;
    [Space(5)]
    public Text DangBan;
    public Slider DangBan_Slider;
    [Space(5)]
    public Text GiaVon;
    public Text GiaBan;
    [Space(5)]
    public Text LoiNhuan;

    public void SetUp()
    {
        TenDuAn.text = duan.TenDuAn;
        ViTri.text = duan.ViTri;
        TongDienTich.text = string.Format("{0:#,###0 'ha}", duan.TongDienTich);
        ThanhPham.text = string.Format("{0:#,###0 'ha}", duan.ThanhPham);
        ThanhPham_Slider.value = duan.ThanhPham / duan.TongDienTich;
        DaBan.text = string.Format("{0:#,###0 'ha}", duan.DaBan);
        DaBan_Slider.value = duan.DaBan / duan.ThanhPham;
        DangBan.text = string.Format("{0:#,###0 'ha}", duan.DangBan);
        DangBan_Slider.value = (duan.DangBan + duan.DaBan) / duan.ThanhPham;
        GiaVon.text = string.Format("{0:#,###0 'VND/m2}", duan.GiaVon);
        GiaBan.text = string.Format("{0:#,###0 'VND/m2}", duan.GiaBan);
        float ln = (duan.GiaBan - duan.GiaVon) * duan.DangBan * 10000;
        LoiNhuan.text = string.Format("{0:#,###0 'VND}", ln);
    }
    public void Delete()
    {
        MainManager.Pannel_Detail.info.DuAn.RemoveAll(s => s.TenDuAn == duan.TenDuAn);
        MainManager.Pannel_Detail.Setup();
        MainManager.Pannel_Detail.Save();
    }

}
