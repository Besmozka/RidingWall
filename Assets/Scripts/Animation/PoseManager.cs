using UnityEngine;

public class PoseManager : MonoBehaviour
{
    [SerializeField]
    private AnimationClip[] animations;

    private float _minTime = 0.5f;
    private float _maxTime = 1.5f;

    internal int AnimationCount { get => animations.Length; }


    public Pose GetPose()
    {
        Pose pose = new Pose();
        var nextClip = animations[Random.Range(0, AnimationCount)];
        nextClip.legacy = true;
        pose.AnimationClip = nextClip;
        pose.AnimationTime = Random.Range(_minTime, _maxTime);
        return pose;
    }
}
