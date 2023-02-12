using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField]
    private IQuestionGenerator.Level level;
    private List<ILevelSelectObserver> observers;
    void Awake() {
        observers = new List<ILevelSelectObserver>();
    }
    public void AddObserver(ILevelSelectObserver observer) {
        observers.Add(observer);
    }
    public void OnClicked() {
        foreach (var observer in observers) {
            observer.Display(this.level);
        }
    }
}
