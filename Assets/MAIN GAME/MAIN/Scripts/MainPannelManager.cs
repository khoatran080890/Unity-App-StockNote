using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPannelManager : MonoBehaviour
{
    public GameObject StockItemHolder;

    public void Setup_Item(StockItemInfo stockiteminfo)
    {
        for (int i = 0; i < StockItemHolder.transform.childCount; i++)
        {
            StockItem stockitem = StockItemHolder.transform.GetChild(i).GetComponent<StockItem>();
            if (stockitem.info.Name == stockiteminfo.Name)
            {
                stockitem.info = stockiteminfo;
                stockitem.Setup();
                Save(stockiteminfo);
                break;
            }
        }
    }
    public void Save(StockItemInfo stockiteminfo)
    {
        string newsave = JsonMapper.ToJson(stockiteminfo);
        SaveLoadManager.Instance.Save(stockiteminfo.Name, "info.txt", newsave);
    }
}
