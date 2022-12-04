using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsService : PanelInterface
{
    private readonly int panelSize;
    private Panels panels;
    private List<bool> question;
    public PanelsService(int panelSize, List<bool> question) {
        this.panelSize = panelSize;
        this.question = new List<bool>();
        foreach (bool state in question) {
            this.question.Add(state);
        }
        panels = new Panels(question);
    }
    public override void OnClicked(Vector2Int pos) {
        List<int> changedPoint = CalcChangedIndex(pos);
        foreach (var point in changedPoint) {
            panels.ReverseAt(point);
        }
        Notify();
    }
    public override void ResetQuestion() {
        panels = new Panels(question);
        Notify();
    }
    public override bool GetState(Vector2Int pos) {
        return panels.GetState(Position2Index(pos));
    }
    public override bool IsCleared() {
        return panels.IsAllTrue();
    }
    private void Notify() {
        foreach (var observer in observers) {
            observer.Display(this);
        }
    }
    private List<int> CalcChangedIndex(Vector2Int pos) {
        List<int> ans = new List<int>();
        List<Vector2Int> mutation = new List<Vector2Int>() { Vector2Int.zero, Vector2Int.up, Vector2Int.left, Vector2Int.right, Vector2Int.down };
        for (int i = 0; i < mutation.Count; i++) {
            if (IsOutOfRange(pos + mutation[i]) == true) { continue; }
            ans.Add(Position2Index(pos + mutation[i]));
        }
        return ans;
    }
    private int Position2Index(Vector2Int pos) {
        return pos.x + pos.y * panelSize;
    }
    private bool IsOutOfRange(Vector2Int pos) {
        if (pos.x < 0 || panelSize <= pos.x) { return true; }
        if (pos.y < 0 || panelSize <= pos.y) { return true; }
        return false;
    }
}
