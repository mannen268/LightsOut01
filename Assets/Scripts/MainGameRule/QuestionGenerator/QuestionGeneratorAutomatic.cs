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
        List<int> points = new List<int>();
        int idx = 0;
        while (idx < 6 + (int)level) {
            Vector2Int point = new Vector2Int(Random.Range(0, panelDim), Random.Range(0, panelDim));
            if (points.Contains(selector.Position2Index(point))) { continue; };
            Debug.Log(idx + " : " + selector.Position2Index(point));
            List<int> changedIndex = selector.GetChangedIndex(point);
            foreach (var index in changedIndex) {
                panels.ReverseAt(index);
            }
            points.Add(selector.Position2Index(point));
            idx++;
        }
        return panels.ToList();
    }
}
