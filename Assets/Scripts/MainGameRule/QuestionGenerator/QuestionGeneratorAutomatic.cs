using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGeneratorAutomatic : IQuestionGenerator
{
    private readonly int panelDim;
    private readonly PanelSelector selector;
    public QuestionGeneratorAutomatic(int panelDim) {
        this.panelDim = panelDim;
        selector = new PanelSelector(panelDim);
    }
    public List<bool> GetQuestion(IQuestionGenerator.Level level) {
        List<bool> question = new List<bool>();
        for (int i = 0; i < panelDim * panelDim; i++) {
            question.Add(true);
        }
        Panels panels = new Panels(question);
        List<Vector2Int> points = GetRandomPositionList(6 + (int)level);
        foreach (var point in points) {
            List<int> changedIndexes = selector.GetChangedIndex(point);
            foreach (var index in changedIndexes) {
                panels.ReverseAt(index);
            }
        }
        return panels.ToList();
    }
    private List<Vector2Int> GetRandomPositionList(int elemCount) {
        List<Vector2Int> points = new List<Vector2Int>();
        int i = 0;
        while (i < elemCount) {
            Vector2Int point = new Vector2Int(Random.Range(0, panelDim), Random.Range(0, panelDim));
            if (points.Contains(point)) { continue; }
            points.Add(point);
            Debug.Log(selector.Position2Index(point));
            i++;
        }
        return points;
    }
}
