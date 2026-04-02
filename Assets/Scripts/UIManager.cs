using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private VisualElement HealthBar;

    [SerializeField] private float DisplayTime = 4.0f;
    private VisualElement NPCDialogueBox;
    private float TimerDisplay;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (TimerDisplay > 0)
        {
            TimerDisplay -= Time.deltaTime;
            if (TimerDisplay < 0)
                NPCDialogueBox.style.display = DisplayStyle.None;
        }
    }

    private void Start()
    {
        UIDocument UiDocument = GetComponent<UIDocument>();
        HealthBar = UiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        UpdateHPBar(1);

        NPCDialogueBox = UiDocument.rootVisualElement.Q<VisualElement>("DialogueUI");
        NPCDialogueBox.style.display = DisplayStyle.None;
        TimerDisplay = 1f;
    }

    public void UpdateHPBar(float Percentage)
    {
        HealthBar.style.width = Length.Percent(100 * Percentage);
    }

    public void DisplayDialogueBox()
    {
        NPCDialogueBox.style.display = DisplayStyle.Flex;
        TimerDisplay = DisplayTime;
    }
}
