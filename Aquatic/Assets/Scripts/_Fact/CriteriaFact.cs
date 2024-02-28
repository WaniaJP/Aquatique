using System;
using UnityEngine;

[Serializable]
public class CriteriaFact 
{
    public int id;
    [SerializeField]
    private Fact item;
    [SerializeField]
    private OperationType operation;
    [SerializeField]

    private int min;
    [SerializeField]

    private int max;

    public event Action OnMeetCrit;


    public CriteriaFact(Fact item, OperationType operation, int min, int max)
    {
        this.item = item;
        this.operation = operation;
        this.min = min;
        this.max = max;

        item.OnFactChanged += AutoCheck;
    }

    public CriteriaFact(Fact item, OperationType operation, int min)
    {
        this.item = item;
        this.operation = operation;
        this.min = min;

        max = -1;

        item.OnFactChanged += AutoCheck;


    }


    public void SetFact(Fact f)
    {
        item = f;
    }

    [Serializable]
    public enum OperationType
    {
        [InspectorName(" ≥ ")] GreaterEqual,
        [InspectorName(" = ")] Equal,
        [InspectorName(" ≤ ")] LessEqual,
        [InspectorName("[...]")] ClosedInterval
    }


    public bool DoesItMeet()
    {
        switch (operation)
        {
            case OperationType.Equal:
                return item.IsEqualTo(min);
            case OperationType.GreaterEqual:
                return item.IsSuperiorOrEqualTo(min);
            case OperationType.LessEqual:
                return item.IsInferiorOrEqualTo(min);
            case OperationType.ClosedInterval:
                return item.IsInferiorOrEqualTo(max) && item.IsSuperiorOrEqualTo(min);
            default:
                Debug.LogError("Invalid operation type.");
                return false;
        }
    }

    public void AutoCheck()
    {
        if (DoesItMeet())
        {
            OnMeetCrit?.Invoke();
            item.OnFactChanged -= AutoCheck;
        }
    }
}
