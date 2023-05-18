using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanel : MonoBehaviour
{

    public Animator animator = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HPanel()
    {
        if (animator != null && animator.GetBool("Activate Panel"))
                {
                    animator.SetBool("Activate Panel", false);
                }
    }
}
