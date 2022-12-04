using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInput : MonoBehaviour
{
    private PanelInterface panelInterface;
    private Vector2Int pos;
    public void Init(PanelInterface panelInterface, Vector2Int pos) {
        this.panelInterface = panelInterface;
        this.pos = pos;
    }
    public void OnClicked() {
        panelInterface.OnClicked(pos);
    }
}
