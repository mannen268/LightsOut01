using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReturnTitleButton
{
    public void AddObserver(IReturnTitleButtonObserver observer);
    public void OnClicked();
    public GameObject GetRootParent();
}
