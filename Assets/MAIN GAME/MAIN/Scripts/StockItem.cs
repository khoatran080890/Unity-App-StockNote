using BestHTTP.JSON.LitJson;
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
    public Text Score;
    [Header("Info")]
    public StockItemInfo info;
    public void ClickStockItem()
    {
        MainManager.Pannel_Detail.info = info;
        MainManager.Pannel_Detail.gameObject.SetActive(true);
    }
    public void Setup()
    {
        Name.text = info.Name;
        Score.text = info.Score.ToString();
    }
    public void ChangeScore(string variablename)
    {
        MainManager.Pannel_ChangeInfo.variable_name = variablename;
        MainManager.Pannel_ChangeInfo.info = info;
        MainManager.Pannel_ChangeInfo.gameObject.SetActive(true);
    }
    
    public void Delete()
    {
        MainManager.Pannel_ConfirmDelete.ShowConfirm(() =>
        {
            SaveLoadManager.Instance.DeleteFolder(Name.text, () =>
            {
                DestroyImmediate(gameObject);
            });
        });
    }
    public void CopyData()
    {
        string jsondata = JsonMapper.ToJson(info);
        Debug.Log(jsondata);

        TextEditor editor = new TextEditor
        {
            text = jsondata
        };
        editor.SelectAll();
        editor.Copy();
    }
}
