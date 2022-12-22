using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestQuestionGenerator
{
    [Test]
    public void TestQuestionGenertor() {
        IQuestionGenerator generator = new QuestionGeneratorAutomatic(5);
        List<bool> question = generator.GetQuestion(IQuestionGenerator.Level.VELY_EASY);
        Assert.That(question.Count, Is.EqualTo(25));
    }
}
