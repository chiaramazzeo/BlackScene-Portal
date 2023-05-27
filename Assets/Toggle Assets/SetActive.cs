using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : MonoBehaviour
{
    public GameObject element;
    public GameObject UI;
    public GameObject Congratulations;
    public Toggle toggle;

    void Start()
    {
        toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggle);
        });
    }

    void ToggleValueChanged(Toggle toggle)
    {
        if (toggle.isOn)
        {
            element.SetActive(true); // Set the element to true if the toggle is on
            UI.SetActive(true);
            Congratulations.SetActive(true);

        }
        else
        {
            element.SetActive(false); // Set the element to false if the toggle is off
            UI.SetActive(false);
            Congratulations.SetActive(false);

        }
    }
}
