using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PanelInterface
{
    protected List<IPanelOutput> observers;
    public PanelInterface() {
        observers = new List<IPanelOutput>();
    }
    public void AddObserver(IPanelOutput observer) {
        observers.Add(observer);
    }
    public abstract void OnClicked(Vector2Int pos);
    public abstract void SetQuestion(List<bool> question);
    public abstract void ResetQuestion();
    public abstract bool GetState(Vector2Int pos);
    public abstract bool IsCleared();
}
