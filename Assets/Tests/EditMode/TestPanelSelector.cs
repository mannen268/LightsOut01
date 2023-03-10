using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPanelSelector
{
    [Test]
    public void TestPosition2Index() {
        PanelSelector selector = new PanelSelector(5);
        Assert.That(selector.Position2Index(new Vector2Int(3, 0)), Is.EqualTo(3));
        Assert.That(selector.Position2Index(new Vector2Int(2, 1)), Is.EqualTo(7));
    }
    [Test]
    public void TestGetChangedIndexWithinRange() {
        List<int> expected = new List<int>() { 12, 17, 7, 11, 13};
        PanelSelector selector = new PanelSelector(5);
        List<int> indexes = selector.GetChangedIndex(new Vector2Int(2, 2));
        for (int i = 0; i < indexes.Count; i++) {
            Assert.That(indexes[i], Is.EqualTo(expected[i]));
        }
    }
    [Test]
    public void TestGetChangedIndexCorner() {
        List<int> expected = new List<int>() { 24, 19, 23};
        PanelSelector selector = new PanelSelector(5);
        List<int> indexes = selector.GetChangedIndex(new Vector2Int(4, 4));
        for (int i = 0; i < indexes.Count; i++) {
            Assert.That(indexes[i], Is.EqualTo(expected[i]));
        }
    }
    [Test]
    public void TestGetChangedIndexOutOfRange() {
        PanelSelector selector = new PanelSelector(5);
        List<int> indexes = selector.GetChangedIndex(new Vector2Int(5, 5));
        Assert.That(indexes.Count, Is.EqualTo(0));
    }
}
