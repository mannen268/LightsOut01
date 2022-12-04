using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : AbstractLevelSelector
{
    private AbstractLevelSelector.Level level;
    private List<string> questionPathDict;
    public LevelSelector() {
        questionPathDict = new List<string>() {
            "./question01.txt",
            "./question02.txt",
            "./question03.txt",
            "./question04.txt",
            "./question05.txt",
        };
    }
    public override void Notify(AbstractLevelSelector.Level level) {
        this.level = level;
        foreach (var observer in observers) {
            observer.Display(this);
        }
    }
    public override string GetQuestionPath() {
        return questionPathDict[(int)level];
    }
}
