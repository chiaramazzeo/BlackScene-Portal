using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInputManager : MonoBehaviour
{

    public GameObject panelToAppear;

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
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray))
                {
                    // Create a particle if hit
                    panelToAppear.SetActive(true);
                }
            }
        }

    }

   
}
