using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsDisable : MonoBehaviour
{
    public GameObject[] objectsToDisable;

    public bool isOn;

    void Start()
    {
        
    }

    public void ToggleValueChanged()
    {
        if (isOn)
        {
            foreach (GameObject obj in objectsToDisable)
            {
            Debug.Log("test");
                obj.SetActive(false);
            }
            isOn= false;
            
        }
        else
        {
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(true);
            }
            isOn = true;
        }
    }
}