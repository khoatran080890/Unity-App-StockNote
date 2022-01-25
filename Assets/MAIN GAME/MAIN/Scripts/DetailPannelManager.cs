using BestHTTP.JSON.LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailPannelManager : MonoBehaviour
{
    [Header("Main Connect")]
    [SerializeField] MainManager MainManager;
    [Header("Info")]
    public StockItemInfo info;
    [Header("Prefabs")]
    public GameObject prefab_DuAnItem;
    public GameObject prefab_GhiChuItem;
    public GameObject prefab_HinhAnhItem;
    public GameObject prefab_LinkThamKhaoItem;
    [Header("UI")]
    [Space(5)]
    public Text Name;
    [Space(5)]
    public Text VCSH;
    [Space(5)]
    public Text VonHoaTT;
    [Space(5)]
    public Text PE;
    public Slider PE_Slider;
    public Text PE_MaxValue;
    public float _PE_MaxValue;
    [Space(5)]
    public Text PB;
    public Slider PB_Slider;
    public Text PB_MaxValue;
    public float _PB_MaxValue;
    [Space(5)]
    public Transform EvaluationHolder;
    public RectTransform EvaluationHolder_1;
    public RectTransform EvaluationHolder_2;
    public RectTransform EvaluationHolder_3;
    public Transform DuAnHolder;
    public Transform GhiChuHolder;
    public Transform HinhAnhHolder;
    public Transform LinkThamKhaoHolder;

    [Header("UI Support")]
    [SerializeField] VerticalLayoutGroup Ver_1;
    [SerializeField] VerticalLayoutGroup Ver_2;
    private void Update()
    {

    }
    private void OnEnable()
    {
        Setup();
    }
    public void Setup()
    {
        Name.text = info.Name;
        VCSH.text = string.Format("{0:#,###0 'VND}", info.VCSH);
        VonHoaTT.text = string.Format("{0:#,###0 'VND}", info.VonHoaTT);
        PE.text = info.PE.ToString();
        PE_MaxValue.text = string.Format("{0:#,###0}", _PE_MaxValue);
        PE_Slider.value = info.PE / _PE_MaxValue;
        float pb = info.VonHoaTT / info.VCSH;
        PB.text = pb.ToString("F2");
        PB_MaxValue.text = string.Format("{0:#,###0}", _PB_MaxValue);
        PB_Slider.value = pb / _PB_MaxValue;

        GameFunction.Instance.DeleteAllChild(LinkThamKhaoHolder.gameObject, () =>
        {
            for (int i = 0; i < info.LinkThamKhao.Count; i++)
            {
                GameObject obj = Instantiate(prefab_LinkThamKhaoItem);
                obj.transform.SetParent(LinkThamKhaoHolder);
                LinkThamKhaoItem hinhanhitem = obj.GetComponent<LinkThamKhaoItem>();
                hinhanhitem.MainManager = MainManager;
                hinhanhitem.LinkThamKhao = info.LinkThamKhao[i];
                hinhanhitem.SetUp();
            }
        });

        GameFunction.Instance.DeleteAllChild(HinhAnhHolder.gameObject, () =>
        {
            for (int i = 0; i < info.HinhAnh.Count; i++)
            {
                GameObject obj = Instantiate(prefab_HinhAnhItem);
                obj.transform.SetParent(HinhAnhHolder);
                HinhAnhItem hinhanhitem = obj.GetComponent<HinhAnhItem>();
                hinhanhitem.MainManager = MainManager;
                hinhanhitem.HinhAnh = info.HinhAnh[i];
                hinhanhitem.SetUp();
            }
        });

        GameFunction.Instance.DeleteAllChild(GhiChuHolder.gameObject, () =>
        {
            for (int i = 0; i < info.GhiChu.Count; i++)
            {
                GameObject obj = Instantiate(prefab_GhiChuItem);
                obj.transform.SetParent(GhiChuHolder);
                GhiChuItem ghichuItem = obj.GetComponent<GhiChuItem>();
                ghichuItem.MainManager = MainManager;
                ghichuItem.ghichu = info.GhiChu[i];
                ghichuItem.SetUp();

            }
        });

        GameFunction.Instance.DeleteAllChild(DuAnHolder.gameObject, () =>
        {
            for (int i = 0; i < info.DuAn.Count; i++)
            {
                GameObject obj = Instantiate(prefab_DuAnItem);
                obj.transform.SetParent(DuAnHolder);
                DuAnItem duAnItem = obj.GetComponent<DuAnItem>();
                duAnItem.MainManager = MainManager;
                duAnItem.duan = info.DuAn[i];
                duAnItem.SetUp();

            }
        });
        Canvas.ForceUpdateCanvases();
        Ver_2.enabled = false;
        Ver_2.enabled = true;
        Ver_1.enabled = false;
        Ver_1.enabled = true;
        

    }
    public void ConfirmChangeInfo(string variable_name, object newvalue)
    {
        switch (variable_name)
        {
            case nameof(StockItemInfo.VCSH):
                info.VCSH = float.Parse(newvalue.ToString());
                break;
            case nameof(StockItemInfo.VonHoaTT):
                info.VonHoaTT = float.Parse(newvalue.ToString());
                break;
            case nameof(StockItemInfo.PE):
                info.PE = float.Parse(newvalue.ToString().Replace(",", "."));
                break;
            default:
                Debug.LogError("No " + variable_name);
                break;
        }

        Setup();
        Save();
    }
    public void Save()
    {
        string newsave = JsonMapper.ToJson(info);
        SaveLoadManager.Instance.Save(info.Name, "info.txt", newsave);
    }
    public void AddDuAn()
    {
        MainManager.Pannel_AddDuAn.gameObject.SetActive(true);
        DuAn emptyduan = new DuAn()
        {
            TenDuAn = "",
            ViTri = "",
            DaBan = 0,
            DangBan = 0,
            TongDienTich = 0,
            GhiChu = "",
            GiaBan = 0,
            GiaVon = 0,
            LoiNhuan = 0,
            ThanhPham = 0,
        };

        MainManager.Pannel_AddDuAn.Setup(emptyduan);
    }
    public void AddGhiChu()
    {
        MainManager.Pannel_AddGhiChu.gameObject.SetActive(true);
    }
    public void AddHinhAnh()
    {
        MainManager.Pannel_AddHinhAnh.gameObject.SetActive(true);
    }
    public void AddLinkThamKhao()
    {
        MainManager.Pannel_AddLinkThamKhao.gameObject.SetActive(true);
    }
    public void ShowChangeInfoPannel(string variablename)
    {
        
        MainManager.Pannel_ChangeInfo.variable_name = variablename;

        MainManager.Pannel_ChangeInfo.gameObject.SetActive(true);
    }
    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
