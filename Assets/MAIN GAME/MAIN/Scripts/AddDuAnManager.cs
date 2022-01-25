using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddDuAnManager : MonoBehaviour
{
    [Header("Main Connect")]
    [SerializeField] MainManager MainManager;
    
    [Header("UI")]
    [SerializeField] InputField TenDuAn;
    [SerializeField] InputField ViTri;
    [SerializeField] InputField TongDienTich;
    [SerializeField] InputField ThanhPham;
    [SerializeField] InputField DaBan;
    [SerializeField] InputField DangBan;
    [SerializeField] InputField GiaVon;
    [SerializeField] InputField GiaBan;
    [SerializeField] InputField LoiNhuan;
    [SerializeField] TMP_InputField GhiChu;

    public void Setup(DuAn duan)
    {
        TenDuAn.text = duan.TenDuAn;
        ViTri.text = duan.ViTri;
        TongDienTich.text = duan.TongDienTich == 0 ? "0" : duan.TongDienTich.ToString();
        ThanhPham.text = duan.ThanhPham == 0 ? "0" : duan.ThanhPham.ToString();
        DaBan.text = duan.DaBan == 0 ? "0" : duan.DaBan.ToString();
        DangBan.text = duan.DangBan == 0 ? "0" : duan.DangBan.ToString();
        GiaVon.text = duan.GiaVon == 0 ? "0" : string.Format("{0:#,###0}", duan.GiaVon);
        GiaBan.text = duan.GiaBan == 0 ? "0" : string.Format("{0:#,###0}", duan.GiaBan);
        LoiNhuan.text = duan.LoiNhuan == 0 ? "0" : string.Format("{0:#,###0}", duan.LoiNhuan);
        GhiChu.text = duan.GhiChu.ToString();
    }
    public void Confirm()
    {
        if (!TenDuAn.text.Equals(string.Empty) 
            && !ViTri.text.Equals(string.Empty)
            && !TongDienTich.text.Equals(string.Empty)
            && !ThanhPham.text.Equals(string.Empty)
            && !DaBan.text.Equals(string.Empty)
            && !DangBan.text.Equals(string.Empty)
            && !GiaVon.text.Equals(string.Empty)
            && !GiaBan.text.Equals(string.Empty)
            && !LoiNhuan.text.Equals(string.Empty))
        {

            foreach (var duan in MainManager.Pannel_Detail.info.DuAn)
            {
                if (TenDuAn.text == duan.TenDuAn)
                {
                    Debug.LogError("Same DuAn Exits => Replace");
                    MainManager.Pannel_Detail.info.DuAn.RemoveAll(x => x.TenDuAn == duan.TenDuAn);
                    break;
                }
            }

            MainManager.Pannel_Detail.info.DuAn.Add(new DuAn()
            {
                TenDuAn = TenDuAn.text,
                ViTri = ViTri.text,
                TongDienTich = float.Parse(TongDienTich.text),
                ThanhPham = float.Parse(ThanhPham.text),
                DaBan = float.Parse(DaBan.text),
                DangBan = float.Parse(DangBan.text),
                GiaVon = float.Parse(GiaVon.text),
                GiaBan = float.Parse(GiaBan.text),
                LoiNhuan = float.Parse(LoiNhuan.text),
                GhiChu = GhiChu.text,
            });
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
