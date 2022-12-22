using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsService : PanelInterface
{
    private readonly PanelSelector selector;
    private Panels panels;
    private List<bool> question;
    public PanelsService(int panelDim, List<bool> question) {
        selector = new PanelSelector(panelDim);
        this.question = new List<bool>();
        SetQuestion(question);
    }
    public override void OnClicked(Vector2Int pos) {
        List<int> changedPoint = selector.GetChangedIndex(pos);
        foreach (var point in changedPoint) {
            panels.ReverseAt(point);
        }
        Notify();
    }
    public override void SetQuestion(List<bool> question) {
        this.question = new List<bool>();
        foreach (bool state in question) {
            this.question.Add(state);
        }
        panels = new Panels(question);
        Notify();
    }
    public override void ResetQuestion() {
        panels = new Panels(question);
        Notify();
    }
    public override bool GetState(Vector2Int pos) {
        return panels.GetState(selector.Position2Index(pos));
    }
    public override bool IsCleared() {
        return panels.IsAllTrue();
    }
}
