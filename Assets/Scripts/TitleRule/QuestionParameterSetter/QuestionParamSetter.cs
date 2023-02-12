using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionParamSetter : AbstractQuestionParamSetter, ILevelSelectObserver, IModeSelectorObserver
{
    private IQuestionGenerator.Level level;
    private Questioner.Mode mode;
    public QuestionParamSetter() {
        level = IQuestionGenerator.Level.VERY_EASY;
    }
    public void Display(IQuestionGenerator.Level level) {
        this.level = level;
        Notify();
    }
    public void Display(Questioner.Mode mode) {
        this.mode = mode;
    }
    public override QuestionSettings GetQuestionSettings() {
        Debug.Log("Mode: " + mode + ", Level: " + level);
        return new QuestionSettings(mode, level);
    }
}
