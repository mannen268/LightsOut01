using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class QuestionGeneratorFromFile
{
    private List<string> questionPathDict;
    public QuestionGeneratorFromFile() {
        questionPathDict = new List<string>() {
            "./question01.txt",
            "./question02.txt",
            "./question03.txt",
            "./question04.txt",
            "./question05.txt",
        };
    }
    public List<bool> GetQuestion(LevelSelectButton.Level level) {
        List<bool> question = new List<bool>();
        var lines = File.ReadLines(questionPathDict[(int)level], Encoding.UTF8);
        // TODO: よりスマートに書ける方法を検討する
        foreach (var line in lines) {
            var texts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var text in texts) {
                question.Add(text == "o" ? true : false);
            }
        }
        return question;
    }
}
