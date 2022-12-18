using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameCanvasManager : MonoBehaviour, IQuestionParamSetterObserver, IPanelOutput, IReturnTitleButtonObserver
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
    private Questioner questioner;
    private QuestionSettings questionSettings;
    void Awake() {
        // Generate Question
        questioner = new Questioner(5);
        List<bool> question = questioner.GetQuestion(questionSettings);
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
        List<bool> question = questioner.GetQuestion(questionSettings);
        panelInterface.SetQuestion(question);
    }
    public void Display(AbstractQuestionParamSetter paramSetter) {
        questionSettings = paramSetter.GetQuestionSettings();
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
