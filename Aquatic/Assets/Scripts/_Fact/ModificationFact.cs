using System;
using UnityEngine;

[Serializable]

public class ModificationFact
{

    public Fact item;
    private readonly OperationType operation;
    private readonly int value;


    public enum OperationType
    {
        [InspectorName(" = ")] Set,
        [InspectorName(" - ")] Remove,
        [InspectorName(" + ")] Add,
    }

    public ModificationFact(Fact item, OperationType operation, int value)
    {
        this.item = item;
        this.operation = operation;
        this.value = value;
    }


    public ModificationFact(Fact item, OperationType operation)
    {
        this.item = item;
        this.operation = operation;
        this.value = 1;
    }

    public bool Process()
    {
        switch (operation)
        {
            case OperationType.Set:
                item.Set(value);
                return true;
            case OperationType.Remove:
                item.Remove(value);
                return true;
            case OperationType.Add:
                item.Add(value);
                return true;
            default:
                Debug.LogError("Invalid operation type.");
                return false;
        }
    }
}
