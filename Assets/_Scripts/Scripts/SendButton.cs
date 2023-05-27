using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendButton : MonoBehaviour
{

public Animator animator = null;

public void Sendanimation() 
{
    animator.SetBool("MessageSent", true);
}

public void Congratulations() 
{
    animator.SetBool("CongIN", true);
}
}



