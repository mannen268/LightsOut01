using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questioner
{
    public enum Mode {
        PREDETERMINE,
        AUTOMATIC
    }
    private List<IQuestionGenerator> generator;
    public Questioner(int panelDim) {
        generator = new List<IQuestionGenerator>();
        generator.Add(new QuestionGeneratorFromFile());
        generator.Add(new QuestionGeneratorAutomatic(panelDim));
    }
    public List<bool> GetQuestion(QuestionSettings settings) {
        return generator[(int)settings.GetQuestionMode()].GetQuestion(settings.GetQuestionLevel());
    }
}
