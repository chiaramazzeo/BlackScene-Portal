using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickInputManager : MonoBehaviour
{

    public GameObject panelToAppear;
    public TextMeshProUGUI objectName, objectDescription, numberOfCompletedText;

    public bool[] objectsCompleted;
    public int numberOfCompleted;

    private ActivatePanel activationScript;

    public void Start()
    {
        activationScript = GetComponent<ActivatePanel>();
    }

    public void OnMouseDown()
    {
        activationScript.TransitionToNextPanel();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.touches);
        foreach (Touch touch in Input.touches)
        {

            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)

                        switch (hit.collider.name)
                        {
                            case "GPS":

                                activationScript.TransitionToNextPanel();

                                break;

                            case "Mask":

                                activationScript.TransitionToNextPanel();

                                break;

                            case "Trophy":

                                activationScript.TransitionToNextPanel();

                                break;
                        }

                    numberOfCompleted = 0;

                    for (int i = 0; i < objectsCompleted.Length; i++)
                    {
                        if(objectsCompleted[i] == true)
                        {
                            numberOfCompleted++;
                        }
                    }

                    numberOfCompletedText.SetText(numberOfCompleted + " / " + objectsCompleted.Length);
                }

               
            }
        }

    }

   
}
