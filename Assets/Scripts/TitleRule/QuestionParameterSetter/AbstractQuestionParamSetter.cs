using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractQuestionParamSetter 
{
    private List<IQuestionParamSetterObserver> observers;
    public AbstractQuestionParamSetter() {
        observers = new List<IQuestionParamSetterObserver>();
    }
    public void AddObserver(IQuestionParamSetterObserver observer) {
        observers.Add(observer);
    }
    protected void Notify() {
        foreach (var observer in observers) {
            observer.Display(this);
        }
    }
    public abstract QuestionSettings GetQuestionSettings();
}
