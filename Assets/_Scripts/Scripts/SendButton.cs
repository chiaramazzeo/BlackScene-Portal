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


public void Congratulations() 
{
    animator.SetBool("CongIN", true);


}

public void FinalButtons() 
{
    animator.SetBool("InstaButtonOn", true);

}

public void ARButton() 
{
    animator.SetBool("ARButtonOn", true);

}

public void ShareOut() 
{
    animator.SetBool("ShareIn", false);

}

public void YourOut() 
{
    animator.SetBool("YourIn", false);

}

}



