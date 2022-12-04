using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractLevelSelector
{
    public enum Level {
        VERY_EASY,
        EASY,
        NORMAL,
        HARD,
        VERY_HARD
    }
    protected List<ILevelSelectorObserver> observers;
    public AbstractLevelSelector() {
        observers = new List<ILevelSelectorObserver>();
    }
    public void AddObserver(ILevelSelectorObserver observer) {
        observers.Add(observer);
    }
    public abstract void Notify(Level level);
    public abstract string GetQuestionPath();
}
