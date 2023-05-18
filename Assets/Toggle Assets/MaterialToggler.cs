using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MaterialToggler : MonoBehaviour
{
    public GameObject targetObject;
    public Material activeMaterial;
    private Material defaultMaterial;
    public float dissolveTime = 1f;
    private bool toggleState = false;

    public void ToggleMaterial()
    {
        toggleState = !toggleState;
        if (toggleState)
        {
            targetObject.GetComponent<Renderer>().material = activeMaterial;
        }
        else
        {
            StartCoroutine(DissolveAndReset());
        }
    }

    private IEnumerator DissolveAndReset()
    {
        // Start the dissolve effect
        float dissolveStartTime = Time.time;
        Material dissolveMaterial = new Material(activeMaterial);
        while (Time.time < dissolveStartTime + dissolveTime)
        {
            float t = (Time.time - dissolveStartTime) / dissolveTime;
            dissolveMaterial.SetFloat("_DissolveAmount", 1 - t);
            targetObject.GetComponent<Renderer>().material = dissolveMaterial;
            yield return null;
        }

        // Reset the material back to the default
        targetObject.GetComponent<Renderer>().material = defaultMaterial;
        toggleState = false;
    }

    private void Awake()
    {
        // Store a reference to the default material
        defaultMaterial = targetObject.GetComponent<Renderer>().material;
    }
}
