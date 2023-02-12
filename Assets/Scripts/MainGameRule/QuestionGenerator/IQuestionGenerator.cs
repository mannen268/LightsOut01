using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuestionGenerator
{
    enum Level {
        VERY_EASY,
        EASY,
        NORMAL,
        HARD,
        VERY_HARD
    }
    public List<bool> GetQuestion(Level level);
}
