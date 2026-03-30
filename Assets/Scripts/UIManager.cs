using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private VisualElement HealthBar;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIDocument UiDocument = GetComponent<UIDocument>();
        HealthBar = UiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        UpdateHPBar(1);
    }

    public void UpdateHPBar(float Percentage)
    {
        HealthBar.style.width = Length.Percent(100 * Percentage);
    }
}
