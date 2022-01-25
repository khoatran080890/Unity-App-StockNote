using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LINE : MonoBehaviour
{
    RectTransform rect;
    public Transform GrandParent;
    public EvaluationLine line1;
    public EvaluationLine line2;
    RectTransform object1;
    RectTransform object2;
    public Vector3 pos1;
    public Vector3 pos2;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
        object1 = line1.dot.GetComponent<RectTransform>();
        object2 = line2.dot.GetComponent<RectTransform>();
        pos1 = GrandParent.InverseTransformPoint(object1.position);
        pos2 = GrandParent.InverseTransformPoint(object2.position);
        RectTransform aux;
        if (pos1.x < pos2.x)
        {
            aux = object1;
            object1 = object2;
            object2 = aux;
        }
        rect.localPosition = (pos1 + pos1) / 2;
        Vector3 dif = pos1 - pos2;
        rect.sizeDelta = new Vector3(dif.magnitude, 5);
        rect.rotation = Quaternion.Euler(new Vector3(0, 0, 180 * Mathf.Atan(dif.y / dif.x) / Mathf.PI));
    }
    private void Update()
    {
        pos1 = GrandParent.InverseTransformPoint(object1.position);
        pos2 = GrandParent.InverseTransformPoint(object2.position);
        RectTransform aux;
        if (pos1.x < pos2.x)
        {
            aux = object1;
            object1 = object2;
            object2 = aux;
        }
        rect.localPosition = (pos1 + pos1) / 2;
        Vector3 dif = pos1 - pos2;
        rect.sizeDelta = new Vector3(dif.magnitude, 5);
        rect.rotation = Quaternion.Euler(new Vector3(0, 0, 180 * Mathf.Atan(dif.y / dif.x) / Mathf.PI));
    }
}
