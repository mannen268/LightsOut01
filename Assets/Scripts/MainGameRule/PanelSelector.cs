using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSelector
{
    private readonly int panelDim;
    private readonly List<Vector2Int> mutation;
    public PanelSelector(int panelDim) {
        this.panelDim = panelDim;
        mutation = new List<Vector2Int>() { Vector2Int.zero, Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right, };
    }
    public List<int> GetChangedIndex(Vector2Int center) {
        List<int> changedIndex = new List<int>();
        foreach (var dir in mutation) {
            if (IsOutOfRange(center + dir)) { continue; }
            changedIndex.Add(Position2Index(center + dir));
        }
        return changedIndex;
    }
    public int Position2Index(Vector2Int pos) {
        return pos.x + pos.y * panelDim;
    }
    private bool IsOutOfRange(Vector2Int pos) {
        if (pos.x < 0 || panelDim <= pos.x) { return true; }
        if (pos.y < 0 || panelDim <= pos.y) { return true; }
        return false;
    }
}
