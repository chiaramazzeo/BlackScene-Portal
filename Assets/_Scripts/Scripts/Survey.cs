using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


public class Survey : MonoBehaviour
{

    [SerializeField] TMP_InputField feedback1;

    string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfH8-pYJtItHKGhqjtoNQjhvcAWh06c9vTc_Jpv6RUjn2M_Eg/formResponse";


    public void Send()
    {
        StartCoroutine(Post(feedback1.text));
    }

    IEnumerator Post(string s1)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.783951237", s1);

        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();

    }


}