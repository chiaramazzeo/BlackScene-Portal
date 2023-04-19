using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDownManager : MonoBehaviour
{
    private ActivatePanel activationScript;

    public void Start()
    {
        activationScript = GetComponent<ActivatePanel>();
    }

    public void OnMouseDown()
    {
        activationScript.TransitionToNextPanel();
    }

}
