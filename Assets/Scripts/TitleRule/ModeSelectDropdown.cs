using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModeSelectDropdown : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    private List<IModeSelectorObserver> observers;
    void Awake() {
        dropdown = GetComponent<TMP_Dropdown>();
        observers = new List<IModeSelectorObserver>();
    }
    public void AddObserver(IModeSelectorObserver observer) {
        observers.Add(observer);
    }
    public void OnChangedValue() {
        Questioner.Mode mode = Questioner.Mode.PREDETERMINE;
        switch (dropdown.value) {
            case 0:
                mode = Questioner.Mode.PREDETERMINE;
                break;
            case 1:
                mode = Questioner.Mode.AUTOMATIC;
                break;
            default:
                break;
        }
        foreach (var observer in observers) {
            observer.Display(mode);
        }
    }
}
