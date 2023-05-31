using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TS.PageSlider;

public class ClickInputManager : MonoBehaviour
{

    private MusicController musicController;
    public GameObject panelToAppear;
    public TextMeshProUGUI objectName, objectDescription;

    public List<Image> imagePanels;
    public List<Sprite> panelImages;

    public Animator animator = null;

    private ActivatePanel activationScript;

    public ScrollDismiss ScrollDismissScript;

    [SerializeField] private PageScroller scroller = null;

    
    public void Start()
    {
        activationScript = GetComponent<ActivatePanel>();
        musicController = FindObjectOfType<MusicController>();
    }

    public void ShowPanel()
    {
        // Setup the images on the panels.
        for (int i = 0; i < imagePanels.Count; i++)
        {
            imagePanels[i].sprite = panelImages[i];
            Debug.Log(panelImages[i]);
        }

        // Show the panels.
        activationScript.TransitionToNextPanel();

        OnEnable();
        
        if (animator != null)
        {
            animator.SetBool("Activate Panel", true);
            animator.SetBool("PanelisUp", false);
            musicController.StartFadeInAndOut();
        }
    }

    /*private void OnMouseDown()
    {
        <ShowPanel();
    }*/

    public void OnEnable()
    {
        scroller?.OverrideToPage(0);
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
                    {
                        ShowPanel();
                    }
                }

               
            }
        }

    }
   
}

