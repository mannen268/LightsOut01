using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour, ILevelSelectObserver, IReturnTitleButtonObserver
{
    [SerializeField]
    private List<LevelSelectButton> levelButtons;
    [SerializeField]
    private GameObject mainGameCanvas;
    void Start()
    {
        foreach (var button in levelButtons) {
            button.AddObserver(this);
            button.AddObserver(mainGameCanvas.GetComponent<ILevelSelectObserver>());
        }
    }
    public void Display(IQuestionGenerator.Level level) {
        gameObject.SetActive(false);
    }
    public void Display(IReturnTitleButton returnTitleButton) {
        gameObject.SetActive(true);
    }
}
