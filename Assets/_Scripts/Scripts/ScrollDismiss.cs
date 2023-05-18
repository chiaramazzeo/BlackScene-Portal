using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScrollDismiss : MonoBehaviour
{
    public ScrollRect scrollRect; // reference to the scroll rect
    public GameObject panelToDismiss; // reference to the panel to dismiss

    private RectTransform cachedTransform;

    public float ThresholdToMove = 5.0f;
    private float initialPoint = 0.0f;

    private bool canTransition = false;

    private Vector3 cachedVelocity = Vector3.zero;

    private float stopLocation;

    public UnityEvent onPanelDismissed;

    public Animator animator = null;

    private void Start()
    {
        scrollRect.onValueChanged.AddListener(OnScrollValueChanged);
        
        cachedTransform = panelToDismiss.GetComponent<RectTransform>();
        initialPoint = cachedTransform.position.y;
        stopLocation = ((cachedTransform.position.y / 2) * -1) + 200;
    }

    private void Update()
    {

        if(CanTransitionDown())
        {
            // Continue moving the panel downwards until it's dismissed.
            Vector3 rectPosition = cachedTransform.position;
            rectPosition.y += cachedVelocity.y * 0.01f;
            //cachedTransform.position = rectPosition;

            // Check if the panel is in position to be fully discarded.
            //if (cachedTransform.position.y < stopLocation )
            {
                scrollRect.velocity = Vector2.zero;
                
                //panelToDismiss.SetActive(false);
                panelToDismiss.transform.position = new Vector3(panelToDismiss.transform.position.x, initialPoint, panelToDismiss.transform.position.z);

                if (animator != null)
                {
                    animator.SetBool("Activate Panel", false);
                    animator.SetBool("PanelisUp", false);
                }

                // Put any code here that you want to run after the panel has been dismissed.
                Debug.Log("Panel has been dismissed.");
                onPanelDismissed.Invoke();
            }
        }
    }

    public bool CanTransitionDown()
    {
        return canTransition;
    }

    private void OnScrollValueChanged(Vector2 value)
    {
        if (value.y <= 0.0f) // check if the scroll view is at the bottom
        {
            //panelToDismiss.SetActive(false); // hide the panel
        }

        float deltaFromStart = initialPoint - panelToDismiss.GetComponent<RectTransform>().position.y;

        if (deltaFromStart < 0f)
        {
            Vector3 position = panelToDismiss.GetComponent<RectTransform>().position;

            scrollRect.velocity = Vector2.zero;
            position.y = initialPoint;
            panelToDismiss.GetComponent<RectTransform>().position = position;
        }

        if (deltaFromStart > ThresholdToMove)
        {
            canTransition = true;
            cachedVelocity = scrollRect.velocity * Vector2.up;
        }

        Debug.Log($"Vector2Input: {value}, myPositionalDeltaFromStart: {deltaFromStart}  ");
    }

}
