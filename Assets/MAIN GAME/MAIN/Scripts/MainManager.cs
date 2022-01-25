using BestHTTP.JSON.LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [Header("Pannel")]
    public AddNamePannelManager Pannel_AddName;
    public LoadStockItemPannel Pannel_LoadStockItem;
    public MainPannelManager Pannel_Main;
    public DetailPannelManager Pannel_Detail;
    public ChangeInfoPannelManager Pannel_ChangeInfo;
    public AddDuAnManager Pannel_AddDuAn;
    public AddGhiChuManager Pannel_AddGhiChu;
    public AddHinhAnhManager Pannel_AddHinhAnh;
    public AddLinkThamKhaoManager Pannel_AddLinkThamKhao;
    public ConfirmDeleteManager Pannel_ConfirmDelete;

    [Header("UI")]
    public TextMeshProUGUI ShowLink;
    public GameObject DebugObj;

    void Start()
    {
        ShowLink.text = Application.persistentDataPath;
        Init();
    }
    public void Refesh()
    {
        Init();
    }
    public void Init()
    {
        GameFunction.Instance.DeleteAllChild(Pannel_Main.StockItemHolder, () =>
        {
            Pannel_Main.gameObject.SetActive(true);
            Pannel_AddName.gameObject.SetActive(false);
            Pannel_Detail.gameObject.SetActive(false);
            Pannel_ChangeInfo.gameObject.SetActive(false);
            Pannel_AddDuAn.gameObject.SetActive(false);
            Pannel_LoadStockItem.gameObject.SetActive(false);
            Pannel_AddHinhAnh.gameObject.SetActive(false);
            Pannel_AddLinkThamKhao.gameObject.SetActive(false);


            DirectoryInfo mainfolder = new DirectoryInfo(Application.persistentDataPath);
            DirectoryInfo[] folderInfo = mainfolder.GetDirectories();
            foreach (var folder in folderInfo)
            {
                if (folder.Name != "il2cpp")
                {
                    Pannel_AddName.CreateNewStockItem(folder.Name, (stockitem) =>
                    {
                        SaveLoadManager.Instance.Load(folder.Name, "info.txt", (data) =>
                        {
                            stockitem.info = JsonMapper.ToObject<StockItemInfo>(data);
                            stockitem.Setup();
                            stockitem.MainManager = this;
                        });
                    });
                }
            }
        });
    }
    public void AddStockItem()
    {
        Pannel_AddName.gameObject.SetActive(true);
    }
    public void LoadStockItem()
    {
        Pannel_LoadStockItem.gameObject.SetActive(true);
    }
    public void ShowDebug()
    {
        DebugObj.SetActive(!DebugObj.activeSelf);
    }

}
