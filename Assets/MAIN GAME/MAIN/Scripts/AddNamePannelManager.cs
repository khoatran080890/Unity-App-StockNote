using BestHTTP.JSON.LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNamePannelManager : MonoBehaviour
{
    [Header("Main Connect")]
    [SerializeField] MainManager MainManager;
    [Header("UI")]
    public InputField Inputfield_Name;
    [Header("Prefabs")]
    [SerializeField] GameObject Prefab_StockItem;
    public void Pannel_AddStockItem_Confirm()
    {
        CreateNewStockItem(MainManager.Pannel_AddName.Inputfield_Name.text, (stockitem) => 
        {
            string newsave = JsonMapper.ToJson(stockitem.info);
            SaveLoadManager.Instance.Save(stockitem.Name.text, "info.txt", newsave);

            gameObject.SetActive(false);
        });
    }
    public void CreateNewStockItem(string name, Action<StockItem> action)
    {
        GameObject obj = Instantiate(Prefab_StockItem);
        obj.transform.SetParent(MainManager.Pannel_Main.StockItemHolder.transform);
        StockItem stockitem = obj.GetComponent<StockItem>();
        stockitem.Name.text = name;
        stockitem.MainManager = MainManager;

        StockItemInfo newdata = new StockItemInfo();
        newdata.Name = name;
        newdata.VCSH = 200000000f;
        newdata.VonHoaTT = 800000000f;
        newdata.PE = 10.2f;
        newdata.PB = newdata.VonHoaTT / newdata.VCSH;
        newdata.DuAn = new List<DuAn>();

        DuAn A = new DuAn();
        A.TenDuAn = "Dự án 1";
        A.ViTri = "Châu Thành, Tiền Giang";
        A.TongDienTich = 54f;
        A.ThanhPham = 20f;
        A.DaBan = 5f;
        A.DangBan = 8f;
        A.GiaVon = 4000000f;
        A.GiaBan = 30000000f;

        DuAn B = new DuAn();
        B.TenDuAn = "Dự án 2";
        B.ViTri = "Châu Thành, Tiền Giang";
        B.TongDienTich = 54f;
        B.ThanhPham = 20f;
        B.DaBan = 5f;
        B.DangBan = 8f;
        B.GiaVon = 4000000f;
        B.GiaBan = 30000000f;

        newdata.DuAn.Add(A);
        newdata.DuAn.Add(B);

        stockitem.info = newdata;
        action?.Invoke(stockitem);
    }
}
