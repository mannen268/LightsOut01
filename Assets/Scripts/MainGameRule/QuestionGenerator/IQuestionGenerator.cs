using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuestionGenerator
{
    enum Level {
        VELY_EASY,
        EASY,
        NORMAL,
        HARD,
        VELY_HARD
    }
    public List<bool> GetQuestion(Level level);
}
