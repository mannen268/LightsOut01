using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFactory : MonoBehaviour
{
    [SerializeField]
    private int panelsSize;
    [SerializeField]
    private GameObject panelUI;
    private Vector2 panelSize = new Vector2(160, 160);
    void Start()
    {
        
    }
    public PanelInterface CreatePanels(string questionPath) {
        QuestionGenerator generator = new QuestionGenerator();
        List<bool> question = generator.GenerateQuestion(questionPath);
        PanelsService panelInterface = new PanelsService(panelsSize, question);
        for (int j = -2; j < 3; j++) {
            for (int i = -2; i < 3; i++) {
                GameObject button = Instantiate(panelUI);
                RectTransform rectTransform = button.GetComponent<RectTransform>();
                rectTransform.SetParent(this.transform);
                rectTransform.localPosition = new Vector3(i * panelSize.x, -1 * j * panelSize.y, 0.0f);
                rectTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                Vector2Int tmpPos = new Vector2Int(i + 2, j + 2);
                button.GetComponent<PanelInput>().Init(panelInterface, tmpPos);
                PanelOutput panelOutput = button.GetComponent<PanelOutput>();
                panelOutput.Init(tmpPos);

                panelInterface.AddObserver(panelOutput);
                panelOutput.Display(panelInterface);
            }
        }

        return panelInterface;
    }
}
