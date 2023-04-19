using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatePanel : MonoBehaviour
{
    [SerializeField] private GameObject objectToDeactivate;
    [SerializeField] private GameObject objectToActivate;

    //public Transform startPos;

    /*private void Start()
    {
        startPos = objectToActivate.transform;
    }*/

    public void TransitionToNextPanel()
    {
        objectToDeactivate.SetActive(false);

        //objectToActivate.transform.position = startPos.position;

        objectToActivate.SetActive(true);
    }
}
