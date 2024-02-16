using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObject : MonoBehaviour
{
    [SerializeField]
    private MapItem map;
    [SerializeField]
    private CriteriaFact itemCrit;
    [SerializeField]
    private Image image;



    private void Start() { 
        itemCrit = new CriteriaFact(MapFactManager.instance.GetFactByName(map.path), CriteriaFact.OperationType.GreaterEqual, 1);
        itemCrit.OnMeetCrit += Meet;
    }

    private void Meet()
    {
        image.sprite = map.visual;
        image.enabled = true;
    }
}
