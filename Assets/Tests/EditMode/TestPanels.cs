using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPanels
{
    [Test]
    public void TestPanelsGetState() {
        Panels panels = new Panels(new List<bool>() { false, true, false });
        Assert.That(panels.GetState(0), Is.False);
        Assert.That(panels.GetState(1), Is.True);
    }
    [Test]
    public void TestPanelIsOutOfRange() {
        Panels panels = new Panels(new List<bool>() { false, true, false });
        Assert.That(panels.ReverseAt(0), Is.True);
        Assert.That(panels.ReverseAt(-1), Is.False);
    }
    [Test]
    public void TestPanelsReverseAt() {
        Panels panels = new Panels(new List<bool>() { false, false, false });
        Assert.That(panels.GetState(0), Is.False);
        panels.ReverseAt(0);
        Assert.That(panels.GetState(0), Is.True);
        panels.ReverseAt(0);
        Assert.That(panels.GetState(0), Is.False);
    }
    [Test]
    public void TestPanelsIsAllTrue() {
        Panels panels = new Panels(new List<bool>() { false, true, true });
        Assert.That(panels.IsAllTrue(), Is.False);
        panels = new Panels(new List<bool> { true, true, true});
        Assert.That(panels.IsAllTrue(), Is.True);
    }
}
