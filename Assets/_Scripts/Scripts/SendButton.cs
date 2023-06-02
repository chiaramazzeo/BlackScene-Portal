using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendButton : MonoBehaviour
{

public Animator animator = null;

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


}
}



