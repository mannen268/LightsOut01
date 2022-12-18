using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModeSelectButton : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    void Awake() {
        dropdown = gameObject.GetComponent<TMP_Dropdown>();
    }
    public void OnChangedValue() {
        if (dropdown == null) { Debug.Log("error"); }
        Debug.Log(dropdown.value);
    }
}
