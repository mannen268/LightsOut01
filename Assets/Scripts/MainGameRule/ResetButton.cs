using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    private PanelInterface panelInterface;
    public void Init(PanelInterface panelInterface) {
        this.panelInterface = panelInterface;
    }
    public void OnClicked() {
        panelInterface.ResetQuestion();
    }
}
