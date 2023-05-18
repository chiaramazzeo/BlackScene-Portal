using UnityEngine;
using UnityEngine.UI;

public class MaterialSwitcher : MonoBehaviour
{
    public Toggle materialToggle;
    public Renderer objectRenderer;
    public Material activeMaterial;
    private Material defaultMaterial;

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
        }
        else
        {
            objectRenderer.material = defaultMaterial;
        }
    }
}
