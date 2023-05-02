using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlaceOnce : MonoBehaviour
{
    public void OnContentPlaced()
    {
        GetComponent<ContentPositioningBehaviour>().AnchorStage = null;
    }
}
