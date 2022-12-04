using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Panels
{
    private List<bool> panels;
    public Panels(List<bool> question) {
        panels = new List<bool>();
        foreach (bool state in question) {
            panels.Add(state);
        }
    }
    public bool GetState(int index) {
        if (IsOutOfRange(index)) { return false; }
        return panels[index];
    }
    public bool IsAllTrue() {
        foreach (bool panel in panels) {
            if (panel == false) { return false; }
        }
        return true;
    }
    public bool ReverseAt(int index) {
        if (IsOutOfRange(index)) { return false; }
        panels[index] = !panels[index];
        return true;
    }
    private bool IsOutOfRange(int index) {
        if (index < 0 || index >+ panels.Count) { return true; }
        return false;
    }
}
