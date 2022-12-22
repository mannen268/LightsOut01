using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModeSelectorObserver
{
    public void Display(Questioner.Mode mode);
}
