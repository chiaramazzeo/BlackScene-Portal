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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogError(Input.touches);
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

                                objectName.SetText("GPS");
                                objectDescription.SetText("GPS description. Bla bla bla");

                                panelToAppear.SetActive(true);

                                objectsCompleted[0] = true;

                                break;

                            case "Mask":

                                objectName.SetText("Surgeon");
                                objectDescription.SetText("Mask description");

                                panelToAppear.SetActive(true);

                                objectsCompleted[1] = true;

                                break;

                            case "Trophy":

                                objectName.SetText("Trophy");
                                objectDescription.SetText("Trophy description. Bla bla bla as well");

                                panelToAppear.SetActive(true);

                                objectsCompleted[2] = true;

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
