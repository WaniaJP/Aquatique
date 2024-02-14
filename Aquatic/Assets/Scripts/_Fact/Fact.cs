
using System;
using System.Collections.Generic;

[Serializable]
public class Fact
{
    private string id;
    public string name;
    public int value;


    public event Action OnFactChanged;

    public Fact(string id, string name, int value)
    {
        this.id = id;
        this.name = name;
        this.value = value;
    }

    public Fact(string id, string name)
    {
        this.id = id;
        this.name = name;
        this.value = 0;
    }

    public Action getEvent(){
        return OnFactChanged;
    }

    public void Add()
    {
        value++;
        OnFactChanged?.Invoke();
    }

    public void Add(int v)
    {
        value+=v;
        OnFactChanged?.Invoke();

    }

    public void Remove()
    {
        value--;
        OnFactChanged?.Invoke();

    }

    public void Remove(int v)
    {
        value -= v;
        OnFactChanged?.Invoke();
    }

    public void Set(int v)
    {
        value = v;
        OnFactChanged?.Invoke();
    }

    public bool IsDone()
    {
        return value > 0;
    }

    public bool IsEqualTo(int v)
    {
        return value == v;
    }

    public bool IsSuperiorOrEqualTo(int v)
    {
        return value >= v;
    }

    public bool IsInferiorOrEqualTo(int v)
    {
        return value <= v;
    }

    public bool IsStrictlySuperiorTo(int v)
    {
        return value > v;
    }

    public bool IsStrictlyInferiorTo(int v)
    {
        return value < v;
    }

}
