using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameCanvasManager : MonoBehaviour, ILevelSelectObserver, IPanelOutput, IReturnTitleButtonObserver
{
    [SerializeField]
    private GameObject titleCanvas;
    [SerializeField]
    private GameObject ClearCanvas;
    [SerializeField]
    private GameObject resetButton;
    [SerializeField]
    private GameObject returnButton;
    private PanelInterface panelInterface;
    private LevelSelectButton.Level level = LevelSelectButton.Level.EASY;
    void Awake() {
        this.GetComponent<PanelFactory>().CreatePanelUI();
        QuestionGeneratorFromFile generator = new QuestionGeneratorFromFile();
        List<bool> question = generator.GetQuestion(level);
        panelInterface = this.GetComponent<PanelFactory>().CreatePanelService(question);
        panelInterface.AddObserver(this);
        panelInterface.AddObserver(ClearCanvas.GetComponent<IPanelOutput>());
        resetButton.GetComponent<ResetButton>().Init(panelInterface);
        returnButton.GetComponent<IReturnTitleButton>().AddObserver(this);
        returnButton.GetComponent<IReturnTitleButton>().AddObserver(titleCanvas.GetComponent<IReturnTitleButtonObserver>());
    }
    void OnEnable() {
        QuestionGeneratorFromFile generator = new QuestionGeneratorFromFile();
        List<bool> question = generator.GetQuestion(level);
        panelInterface.SetQuestion(question);
    }
    public void Display(LevelSelectButton.Level level) {
        this.level = level;
        gameObject.SetActive(true);
    }
    public void Display(PanelInterface panelInterface) {
        if (panelInterface.IsCleared() == true) {
            gameObject.SetActive(false);
        }
    }
    public void Display(IReturnTitleButton returnTitleButton) {
        if (returnTitleButton.GetRootParent() == this.gameObject) {
            gameObject.SetActive(false);
            return;
        }
        gameObject.SetActive(true);
    }
}
