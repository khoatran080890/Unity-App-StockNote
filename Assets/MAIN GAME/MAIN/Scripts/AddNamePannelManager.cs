using BestHTTP.JSON.LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

    private void OnEnable()
    {
        Inputfield_Name.text = "";
    }
    public void Pannel_AddStockItem_Confirm()
    {
        DirectoryInfo mainfolder = new DirectoryInfo(Application.persistentDataPath);
        DirectoryInfo[] folderInfo = mainfolder.GetDirectories();
        foreach (var folder in folderInfo)
        {
            if (MainManager.Pannel_AddName.Inputfield_Name.text == folder.Name)
            {
                Debug.LogError("Same Name Exits");
                return;
            }
        }

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

        StockItemInfo newdata = new StockItemInfo();
        newdata.Name = name;
        newdata.Score = 0;
        newdata.VCSH = 200000000f;
        newdata.VonHoaTT = 800000000f;
        newdata.PE = 5f;

        stockitem.info = newdata;

        stockitem.Setup();
        stockitem.MainManager = MainManager;
        action?.Invoke(stockitem);
    }
    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
