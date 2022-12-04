using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelSelectorObserver
{
    public void Display(AbstractLevelSelector levelSelector);
}
