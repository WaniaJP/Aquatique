using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObject : MonoBehaviour
{

    public bool WasDiscovered;
    public MapItem map;

    public Image image;

    [SerializeField]

    private CriteriaFact itemCrit;

    [SerializeField]
    private Fact item;

    private void Start()
    {
        item = TestFact.instance.GetFactByName(map.path);
        itemCrit = new CriteriaFact(item, CriteriaFact.OperationType.GreaterEqual, 1);
        itemCrit.OnMeetCrit += Meet;
    }

    private void Meet()
    {
        Debug.LogWarning("Here with : " + map.path);
        WasDiscovered = true;
        image.sprite = map.visual;

        image.enabled = true;
    }
}
