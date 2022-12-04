using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCanvasManager : MonoBehaviour, IPanelOutput, IReturnTitleButtonObserver
{
    [SerializeField]
    private GameObject titleCanvas;
    [SerializeField]
    private GameObject returnTitleButton;
    void Start() {
        IReturnTitleButton returnTitleButton = this.returnTitleButton.GetComponent<IReturnTitleButton>();
        returnTitleButton.AddObserver(this);
        returnTitleButton.AddObserver(titleCanvas.GetComponent<IReturnTitleButtonObserver>());
    }
    public void Display(PanelInterface panelInterface) {
        if (panelInterface.IsCleared() == true) {
            gameObject.SetActive(true);
        }
    }
    public void Display(IReturnTitleButton returnTitleButton) {
        gameObject.SetActive(false);
    }
}
