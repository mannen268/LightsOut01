using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTitleButton : MonoBehaviour, IReturnTitleButton
{
    private List<IReturnTitleButtonObserver> observers;
    void Awake() {
        observers = new List<IReturnTitleButtonObserver>();
    }
    public void AddObserver(IReturnTitleButtonObserver observer) {
        observers.Add(observer);
    }
    public void OnClicked() {
        foreach (var observer in observers) {
            observer.Display(this);
        }
    }
    public GameObject GetRootParent() {
        return transform.root.gameObject;
    }
}
