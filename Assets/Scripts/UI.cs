using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Button buttonPrefab;
    public Canvas canvas;

    public List<Button> buttons = new List<Button>();

    public GridHandler gridHandler;
    // Start is called before the first frame update
    void Start()
    {
        canvas = this.GetComponentInParent<Canvas>();
        CreateHorizontalLayout();
        CreateButtons();
        /*Button newButton = Instantiate(buttonPrefab) as Button;
        newButton.transform.SetParent(canvas.transform, false);
        newButton.image.color = gridHandler.states[1];
        newButton.onClick.AddListener(() => gridHandler.ChangeSelectedState(1)); */

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateButtons()
    {
        for (int i = 1; i < gridHandler.states.Count; i++)
        {
            int myI = i;
            Button newButton = Instantiate(buttonPrefab) as Button;
            newButton.transform.SetParent(canvas.transform, false);
            newButton.transform.localScale = new Vector2(1, 1);
            newButton.image.color = gridHandler.states[myI];
            newButton.onClick.AddListener(() => { gridHandler.ChangeSelectedState(myI); });
            buttons.Add(newButton);
        }
    }

    private void CreateHorizontalLayout()
    {
        HorizontalLayoutGroup hlg = this.gameObject.AddComponent<HorizontalLayoutGroup>();
        hlg.childControlHeight = false;
        hlg.childControlWidth = false;
        hlg.childForceExpandHeight = false;
        hlg.childForceExpandWidth = false;
        hlg.padding = new RectOffset(3, 3, 3, 3);
        hlg.spacing = 3;
        hlg.childAlignment = TextAnchor.LowerLeft;
    }
}
