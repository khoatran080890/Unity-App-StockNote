using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
   
}

[Serializable]
public class StockItemInfo
{
    public string Name;
    public float VCSH;
    public float VonHoaTT;
    public float PE;
    //public float PB;
    public List<DuAn> DuAn = new List<DuAn>();
}
[Serializable]
public class DuAn
{
    public string TenDuAn;
    public string ViTri;
    public float TongDienTich;
    public float ThanhPham;
    public float DaBan;
    public float DangBan;
    public float GiaBan;
    public float GiaVon;
}

