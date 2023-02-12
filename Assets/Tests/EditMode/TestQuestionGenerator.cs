using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestQuestionGenerator
{
    [Test]
    public void TestQuestionGeneratorFromFileVeryEasy() {
        List<bool> expected = new List<bool>() {
            true, false, true, false, true,
            false, false, true, false, false,
            true, true, true, true, true,
            false, false, true, false, false,
            true, false, true, false, true,
        }; 
        IQuestionGenerator generator = new QuestionGeneratorFromFile();
        List<bool> question = generator.GetQuestion(IQuestionGenerator.Level.VERY_EASY);
        for (int i = 0; i < question.Count; i++) {
            Assert.That(question[i], Is.EqualTo(expected[i]));
        }
    }
    [Test]
    public void TestQuestionGeneratorFromFileEasy() {
        List<bool> expected = new List<bool>() {
            false, true, true, false, true,
            false, false, true, false, false,
            false, true, false, true, false,
            false, false, true, false, false,
            true, false, true, true, false,
        };
        IQuestionGenerator generator = new QuestionGeneratorFromFile();
        List<bool> question = generator.GetQuestion(IQuestionGenerator.Level.EASY);
        for (int i = 0; i < question.Count; i++) {
            Assert.That(question[i], Is.EqualTo(expected[i]));
        }
    }
    [Test]
    public void TestQuestionGeneratorFromFileNormal() {
        List<bool> expected = new List<bool>() {
            true, true, false, false, true,
            true, true, false, true, false,
            false, true, true, true, true,
            true, true, true, false, true,
            true, true, false, true, true,
        };
        IQuestionGenerator generator = new QuestionGeneratorFromFile();
        List<bool> question = generator.GetQuestion(IQuestionGenerator.Level.NORMAL);
        for (int i = 0; i < question.Count; i++) {
            Assert.That(question[i], Is.EqualTo(expected[i]));
        }
    }
    [Test]
    public void TestQuestionGeneratorFromFileHard() {
        List<bool> expected = new List<bool>() {
            true, false, false, false, false,
            true, false, true, false, true,
            true, false, false, false, true,
            false, true, false, true, true,
            false, false, false, false, true,
        };
        IQuestionGenerator generator = new QuestionGeneratorFromFile();
        List<bool> question = generator.GetQuestion(IQuestionGenerator.Level.HARD);
        for (int i = 0; i < question.Count; i++) {
            Assert.That(question[i], Is.EqualTo(expected[i]));
        }
    }
    [Test]
    public void TestQuestionGeneratorFromFileVeryHard() {
        List<bool> expected = new List<bool>() {
            true, false, true, false, false,
            true, false, true, true, true,
            true, false, false, true, true,
            false, false, false, false, false,
            false, false, true, false, false,
        };
        IQuestionGenerator generator = new QuestionGeneratorFromFile();
        List<bool> question = generator.GetQuestion(IQuestionGenerator.Level.VERY_HARD);
        for (int i = 0; i < question.Count; i++) {
            Assert.That(question[i], Is.EqualTo(expected[i]));
        }
    }
    [Test]
    public void TestQuestionGeneratorAutomatic() {
        IQuestionGenerator generator = new QuestionGeneratorAutomatic(5);
        List<bool> question = generator.GetQuestion(IQuestionGenerator.Level.VERY_EASY);
        Assert.That(question.Count, Is.EqualTo(25));
    }
}
