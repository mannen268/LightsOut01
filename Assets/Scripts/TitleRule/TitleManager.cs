using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour, IQuestionParamSetterObserver, IReturnTitleButtonObserver
{
    [SerializeField]
    private List<LevelSelectButton> levelButtons;
    [SerializeField]
    private ModeSelectDropdown modeDoropdown;
    [SerializeField]
    private GameObject mainGameCanvas;
    void Start()
    {
        QuestionParamSetter paramSetter = new QuestionParamSetter();
        paramSetter.AddObserver(this);
        paramSetter.AddObserver(mainGameCanvas.GetComponent<IQuestionParamSetterObserver>());
        foreach (var button in levelButtons) {
            button.AddObserver(paramSetter);
        }
        modeDoropdown.AddObserver(paramSetter);
    }
    public void Display(AbstractQuestionParamSetter paramSetter) {
        gameObject.SetActive(false);
    }
    public void Display(IReturnTitleButton returnTitleButton) {
        gameObject.SetActive(true);
    }
}
