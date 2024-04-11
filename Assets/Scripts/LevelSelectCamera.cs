using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectCamera : MonoBehaviour
{
    public Animator camAnimator;

    public void SwitchCamera()
    {
        bool isSelectingLevel = camAnimator.GetBool("isSelectingLevel");
        camAnimator.SetBool("isSelectingLevel", !isSelectingLevel);
    }
}
