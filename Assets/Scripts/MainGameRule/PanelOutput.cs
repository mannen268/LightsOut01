using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOutput : MonoBehaviour, IPanelOutput
{
    private Vector2Int pos;
    private Image appearance;
    public void Init(Vector2Int pos) {
        this.pos = pos;
        appearance = GetComponent<Image>();
    }
    public void Display(PanelInterface panelInterface) {
        appearance.color = panelInterface.GetState(pos) ? new Color32(255, 255, 255, 255) : new Color32(125, 125, 125, 255);
    }
}
