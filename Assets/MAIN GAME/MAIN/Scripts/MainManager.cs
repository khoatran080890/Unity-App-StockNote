using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [Header("Pannel")]
    public AddNamePannelManager Pannel_AddName;
    public MainPannelManager Pannel_Main;
    public DetailPannelManager Pannel_Detail;
    public ChangeInfoPannelManager Pannel_ChangeInfo;
    public AddDuAnManager Pannel_AddDuAn;

    void Start()
    {
        Pannel_Main.gameObject.SetActive(true);
        Pannel_AddName.gameObject.SetActive(false);
        Pannel_Detail.gameObject.SetActive(false);
        Pannel_ChangeInfo.gameObject.SetActive(false);
        Pannel_AddDuAn.gameObject.SetActive(false);



        DirectoryInfo mainfolder = new DirectoryInfo(Application.streamingAssetsPath);
        DirectoryInfo[] folderInfo = mainfolder.GetDirectories();
        foreach (var folder in folderInfo)
        {
            Pannel_AddName.CreateNewStockItem(folder.Name, (stockitem) =>
            {
                SaveLoadManager.Instance.Load(folder.Name, "info.txt", (data) =>
                {
                    stockitem.info = JsonMapper.ToObject<StockItemInfo>(data);
                    stockitem.MainManager = this;
                });
            });
        }

    }

    public void AddStockItem()
    {
        Pannel_AddName.gameObject.SetActive(true);
    }
    


}
