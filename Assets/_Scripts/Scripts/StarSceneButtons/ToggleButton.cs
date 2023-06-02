using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public Toggle toggle;

    private Button button;

    public void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ToggleValue);
    }

    public void ToggleValue()
    {
        toggle.isOn = !toggle.isOn;
    }
}

