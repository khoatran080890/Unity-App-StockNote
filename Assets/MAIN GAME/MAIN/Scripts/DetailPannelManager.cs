using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailPannelManager : MonoBehaviour
{
    [Header("Info")]
    public StockItemInfo info;
    [Header("Prefabs")]
    public GameObject prefab_DuAnItem;
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
    public Transform DuAnHolder;
    
    private void OnEnable()
    {
        Setup();
    }
    public void Setup()
    {
        Name.text = info.Name;
        VCSH.text = string.Format("{0:#,###0 'VND}", info.VCSH);
        VonHoaTT.text = string.Format("{0:#,###0 'VND}", info.VonHoaTT);
        PE.text = string.Format("{0:#,###0}", info.PE);
        PE_MaxValue.text = string.Format("{0:#,###0}", _PE_MaxValue);
        PE_Slider.value = info.PE / _PE_MaxValue;
        PB.text = string.Format("{0:#,###0}", info.PB);
        PB_MaxValue.text = string.Format("{0:#,###0}", _PB_MaxValue);
        PB_Slider.value = info.PB / _PB_MaxValue;

        GameFunction.Instance.DeleteAllChild(prefab_DuAnItem, () =>
        {
            for (int i = 0; i < info.DuAn.Count; i++)
            {
                GameObject obj = Instantiate(prefab_DuAnItem);
                obj.transform.SetParent(DuAnHolder);
                DuAnItem duAnItem = obj.GetComponent<DuAnItem>();
                duAnItem.duan = info.DuAn[i];
                duAnItem.SetUp();

            }
        });
        
    }
    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
