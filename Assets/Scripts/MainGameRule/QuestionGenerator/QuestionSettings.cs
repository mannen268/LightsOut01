using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSettings
{
    private Questioner.Mode mode;
    private IQuestionGenerator.Level level;
    public QuestionSettings(Questioner.Mode mode, IQuestionGenerator.Level level) {
        this.mode = mode;
        this.level = level;
    }
    public Questioner.Mode GetQuestionMode() {
        return mode;
    }
    public IQuestionGenerator.Level GetQuestionLevel() {
        return level;
    }
}
