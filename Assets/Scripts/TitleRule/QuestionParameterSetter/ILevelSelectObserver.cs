using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelSelectObserver
{
    public void Display(IQuestionGenerator.Level level);
}
