using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameCanvasManager : MonoBehaviour, ILevelSelectorObserver, IPanelOutput, IReturnTitleButtonObserver
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
    void OnEnable() {
        panelInterface.AddObserver(this);
        panelInterface.AddObserver(ClearCanvas.GetComponent<IPanelOutput>());
    }
    void Start() {
        returnButton.GetComponent<IReturnTitleButton>().AddObserver(this);
        returnButton.GetComponent<IReturnTitleButton>().AddObserver(titleCanvas.GetComponent<IReturnTitleButtonObserver>());
    }
    public void Display(AbstractLevelSelector levelSelector) {
        panelInterface = this.GetComponent<PanelFactory>().CreatePanels(levelSelector.GetQuestionPath());
        resetButton.GetComponent<ResetButton>().Init(panelInterface);
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
