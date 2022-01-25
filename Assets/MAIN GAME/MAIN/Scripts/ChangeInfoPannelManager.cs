using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInfoPannelManager : MonoBehaviour
{
    [Header("Main Connect")]
    [SerializeField] MainManager MainManager;
    [Header("UI")]
    public InputField Inputfield_value;
    public Toggle Toggle_Milionare;
    public Text Title;
    [Header("Code")]
    public string variable_name;
    public StockItemInfo info;

    private void OnEnable()
    {
        switch (variable_name)
        {
            case nameof(StockItemInfo.VCSH):
                Inputfield_value.contentType = InputField.ContentType.IntegerNumber;
                Toggle_Milionare.gameObject.SetActive(true);
                break;
            case nameof(StockItemInfo.VonHoaTT):
                Inputfield_value.contentType = InputField.ContentType.IntegerNumber;
                Toggle_Milionare.gameObject.SetActive(true);
                break;
            case nameof(StockItemInfo.PE):
                Inputfield_value.contentType = InputField.ContentType.DecimalNumber;
                Toggle_Milionare.gameObject.SetActive(false);
                break;
            case nameof(StockItemInfo.Score):
                Inputfield_value.contentType = InputField.ContentType.DecimalNumber;
                Toggle_Milionare.gameObject.SetActive(false);
                break;
            default:
                Debug.LogError("No " + variable_name);
                Toggle_Milionare.gameObject.SetActive(false);
                break;
        }
        Title.text = variable_name;
        Inputfield_value.text = "";
        Toggle_Milionare.isOn = false;
    }
    public void Confirm()
    {
        if (!Inputfield_value.text.Equals(string.Empty))
        {
            switch (variable_name)
            {
                case nameof(StockItemInfo.VCSH):
                case nameof(StockItemInfo.VonHoaTT):
                case nameof(StockItemInfo.PE):
                    string addedstring = Toggle_Milionare.isOn ? "000000000" : "";
                    MainManager.Pannel_Detail.ConfirmChangeInfo(variable_name, Inputfield_value.text + addedstring);
                    gameObject.SetActive(false);
                    break;
                case nameof(StockItemInfo.Score):
                    info.Score = float.Parse(Inputfield_value.text);
                    MainManager.Pannel_Main.Setup_Item(info);
                    gameObject.SetActive(false);
                    break;
            }
            
        }
    }
    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
