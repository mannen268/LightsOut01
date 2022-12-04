using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPanels
{
    [Test]
    public void TestPanelsReverseAt() {
        List<bool> question = new List<bool>() { false, false, false };
        Panels panels = new Panels(question);
        Assert.That(panels.ReverseAt(0), Is.True);
        Assert.That(panels.ReverseAt(-1), Is.False);
    }
    [Test]
    public void TestPanelsIsAllTrue() {
        Panels panels = new Panels(new List<bool>() { false, true, true });
        Assert.That(panels.IsAllTrue(), Is.False);
        panels = new Panels(new List<bool> { true, true, true});
        Assert.That(panels.IsAllTrue(), Is.True);
    }
    [Test]
    public void TestPanelsGetState() {
        Panels panels = new Panels(new List<bool>() { false, true, false});
        Assert.That(panels.GetState(0), Is.False);
        Assert.That(panels.GetState(1), Is.True);
    }
    //[Test]
    //public void TestPanelsChangeAt() {
    //    Panels panels = new Panels(5);
    //    Assert.That(panels.ReverseAt(0), Is.True);
    //    Assert.That(panels.ReverseAt(-1), Is.False);
    //}

    //[Test]
    //public void TestPanelsService() {
    //    List<IDisplayedPanels> displayedPanels = new List<IDisplayedPanels>();
    //    for (int i = 0; i < 5 * 5; i++) {
    //        IDisplayedPanels output = new OutputFile();
    //        displayedPanels.Add(output);
    //    }
    //    PanelsService ps = new PanelsService(displayedPanels, 5);
    //    Vector2Int center = new Vector2Int(2, 2);
    //    ps.OnClicked(center);
    //}

    //[Test]
    //public void TestOutputFile() {
    //    IDisplayedPanels outputFile = new OutputFile();
    //    List<bool> panels = new List<bool>();
    //    for (int i = 0; i < 25; i++) {
    //        panels.Add(true);
    //    }
    //    outputFile.Display(panels);
    //}
}
