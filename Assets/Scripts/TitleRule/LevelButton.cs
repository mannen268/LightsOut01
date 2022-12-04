using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    private AbstractLevelSelector.Level level;
    private AbstractLevelSelector levelSelector;
    public void Init(AbstractLevelSelector levelSelector) {
        this.levelSelector = levelSelector;
    }
    public void OnClicked() {
        levelSelector.Notify(level);
    }
}
