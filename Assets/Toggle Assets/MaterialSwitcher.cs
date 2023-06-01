using UnityEngine;
using UnityEngine.UI;

public class MaterialSwitcher : MonoBehaviour
{
    public Toggle materialToggle;
    public Renderer objectRenderer;
    public Material activeMaterial;
    private Material defaultMaterial;

    public GameObject objectToActivate1;
    public GameObject objectToActivate2;

    void Start()
    {
        defaultMaterial = objectRenderer.material;
        materialToggle.onValueChanged.AddListener(ToggleMaterial);
    }

    void ToggleMaterial(bool isActive)
    {
        if (isActive)
        {
            objectRenderer.material = activeMaterial;
            if (objectToActivate1 != null)
            {
                objectToActivate1.SetActive(true);
            }
            if (objectToActivate2 != null)
            {
                objectToActivate2.SetActive(true);
            }
        }
        else
        {
            objectRenderer.material = defaultMaterial;
            if (objectToActivate1 != null)
            {
                objectToActivate1.SetActive(false);
            }
            if (objectToActivate2 != null)
            {
                objectToActivate2.SetActive(false);
            }
        }
    }
}

