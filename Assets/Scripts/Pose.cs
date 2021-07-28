using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pose
{
    private AnimationClip animationClip;
    private float _animationTime;
    public AnimationClip AnimationClip { get => animationClip; set => animationClip = value; }
    public float AnimationTime { get => _animationTime; set => _animationTime = value; }

}
