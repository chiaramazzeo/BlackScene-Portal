using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendButton : MonoBehaviour
{

public Animator animator = null;
    public GameObject buttonImage1;
    public GameObject buttonImage2;

public void Sendanimation() 
{
    animator.SetBool("MessageSent", true);
}

public void OutPhrase1() 
{
    animator.SetBool("OutPhrase1", true);
}

public void Congratulations() 
{
    animator.SetBool("CongIN", true);
        buttonImage1.SetActive(true);
        buttonImage2.SetActive(true);


}
}



