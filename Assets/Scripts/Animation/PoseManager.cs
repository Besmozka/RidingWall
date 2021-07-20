using UnityEngine;

public class PoseManager : MonoBehaviour
{
    public AnimationClip[] animations;

    private int _currentClip;
    private float _animationTime;

    internal int AnimationCount { get => animations.Length; }
    public float AnimationTime { get => _animationTime; set => _animationTime = value; }
}
