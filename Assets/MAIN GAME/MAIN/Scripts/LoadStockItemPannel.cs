using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadStockItemPannel : MonoBehaviour
{
    [Header("Main Connect")]
    [SerializeField] MainManager MainManager;
    [Header("UI")]
    public InputField Inputfield_data;
    private void OnEnable()
    {
        Inputfield_data.text = "";
    }
    public void Confirm()
    {
        if (!Inputfield_data.text.Equals(string.Empty))
        {
            string foldername = JsonMapper.ToObject<StockItemInfo>(Inputfield_data.text).Name;
            MainManager.Pannel_AddName.CreateNewStockItem(foldername, (stockitem) =>
            {
                SaveLoadManager.Instance.Save(foldername, "info.txt", Inputfield_data.text);
                MainManager.Refesh();
                gameObject.SetActive(false);
            });
        }
    } 
    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
