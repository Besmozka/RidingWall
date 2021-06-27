using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPose 
{
    public Vector3 LeftArmPoint { get; private set; }
    public Vector3 RigthArmPoint { get; private set; }
    public Vector3 LeftLegPoint { get; private set; }
    public Vector3 RigthLegPoint { get; private set; }
    public Vector3 LeftHandPoint { get; private set; }
    public Vector3 RigthHandPoint { get; private set; }

    public PlayerPose(Vector3 leftArmPoint, Vector3 rigthArmPoint, Vector3 leftLegPoint, Vector3 rigthLegPoint, Vector3 leftHandPoint, Vector3 rigthHandPoint)
    {
        LeftArmPoint = leftArmPoint;
        RigthArmPoint = rigthArmPoint;
        LeftLegPoint = leftLegPoint;
        RigthLegPoint = rigthLegPoint;
        LeftHandPoint = leftHandPoint;
        RigthHandPoint = rigthHandPoint;
    }
}
