using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockItem : MonoBehaviour
{
    [Header("MainManager connect")]
    public MainManager MainManager;
    [Header("UI")]
    public Text Name;
    [Header("Info")]
    public StockItemInfo info;
    public void ClickStockItem()
    {
        MainManager.Pannel_Detail.info = info;
        MainManager.Pannel_Detail.gameObject.SetActive(true);
    }
    public void Delete()
    {
        SaveLoadManager.Instance.DeleteFolder(Name.text, ()=> 
        {
            DestroyImmediate(gameObject);
        });
    }
}
