using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class QuestionGenerator
{
    public List<bool> GenerateQuestion(string filePath) {
        List<bool> question = new List<bool>();
        var lines = File.ReadLines(filePath, Encoding.UTF8);
        foreach (var line in lines) {
            var texts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var text in texts) {
                question.Add(text == "o" ? true : false);
            }
        }
        return question;
    }
}
