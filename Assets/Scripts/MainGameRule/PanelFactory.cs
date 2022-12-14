using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFactory : MonoBehaviour
{
    [SerializeField]
    private int panelDim;
    [SerializeField]
    private GameObject panelUIPrefab;
    private List<GameObject> panelUIInstances;
    private Vector2 panelSize = new Vector2(160, 160);
    public void CreatePanelUI() {
        panelUIInstances = new List<GameObject>();
        for (int j = 0; j < panelDim; j++) {
            for (int i = 0; i < panelDim; i++) {
                GameObject button = Instantiate(panelUIPrefab);
                RectTransform rectTransform = button.GetComponent<RectTransform>();
                rectTransform.SetParent(this.transform);
                rectTransform.localPosition = new Vector3((i - panelDim / 2) * panelSize.x, -1 * (j - panelDim / 2) * panelSize.y, 0.0f);
                rectTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                Vector2Int tmpPos = new Vector2Int(i, j);
                button.GetComponent<PanelInput>().Init(tmpPos);
                button.GetComponent<PanelOutput>().Init(tmpPos);
                panelUIInstances.Add(button);
            }
        }
    }
    public PanelInterface CreatePanelService(List<bool> question) {
        PanelsService panelsService = new PanelsService(panelDim, question);
        foreach (var panelInstance in panelUIInstances) {
            panelInstance.GetComponent<PanelInput>().SetPanelInterface(panelsService);
            panelsService.AddObserver(panelInstance.GetComponent<PanelOutput>());
            panelInstance.GetComponent<PanelOutput>().Display(panelsService);
        }
        return panelsService;
    }
}
