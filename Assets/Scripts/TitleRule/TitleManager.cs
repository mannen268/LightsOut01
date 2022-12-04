using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour, ILevelSelectorObserver, IReturnTitleButtonObserver
{
    [SerializeField]
    private List<LevelButton> levelButton;
    [SerializeField]
    private GameObject mainGameCanvas;
    void Start()
    {
        LevelSelector levelSelector = new LevelSelector();
        levelSelector.AddObserver(this);
        levelSelector.AddObserver(mainGameCanvas.GetComponent<ILevelSelectorObserver>());
        foreach (var button in levelButton) {
            button.GetComponent<LevelButton>().Init(levelSelector);
        }
    }
    public void Display(AbstractLevelSelector levelSelector) {
        gameObject.SetActive(false);
    }
    public void Display(IReturnTitleButton returnTitleButton) {
        gameObject.SetActive(true);
    }
}
