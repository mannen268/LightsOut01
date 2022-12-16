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
    private PanelFactory panelFactory;
    private PanelInterface panelInterface;
    private IQuestionGenerator questionGenerator;
    private IQuestionGenerator.Level level = IQuestionGenerator.Level.VELY_EASY;
    void Awake() {
        // Generate Question
        questionGenerator = new QuestionGeneratorAutomatic(5);
        //questionGenerator = new QuestionGeneratorFromFile();
        List<bool> question = questionGenerator.GetQuestion(level);
        // Setup Panels
        panelFactory = GetComponent<PanelFactory>();
        panelFactory.CreatePanelUI();
        panelInterface = panelFactory.CreatePanelService(question);
        panelInterface.AddObserver(this);
        panelInterface.AddObserver(ClearCanvas.GetComponent<IPanelOutput>());
        // Setup UI button
        resetButton.GetComponent<ResetButton>().Init(panelInterface);
        returnButton.GetComponent<IReturnTitleButton>().AddObserver(this);
        returnButton.GetComponent<IReturnTitleButton>().AddObserver(titleCanvas.GetComponent<IReturnTitleButtonObserver>());
    }
    void OnEnable() {
        List<bool> question = questionGenerator.GetQuestion(level);
        panelInterface.SetQuestion(question);
    }
    public void Display(IQuestionGenerator.Level level) {
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
