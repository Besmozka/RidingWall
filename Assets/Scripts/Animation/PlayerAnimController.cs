
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class PlayerAnimController : MonoBehaviour
{  
    public Animation animation;

    private int _currentClip;
    public AnimationClip idleClip;
    public AnimationClip[] animations;

    internal int AnimationCount { get => animations.Length; }

    private float _animationTime;
    public float AnimationTime { get => _animationTime; set => _animationTime = value; }

    void Awake()
    {
        animation = GetComponent<Animation>();
        animation.AddClip(idleClip, "Idle");
        animation.Play("Idle");
        for (int i = 0; i < animations.Length; i++)
        {
            animation.AddClip(animations[0], i.ToString());
        }
    }

    public void NextPose()
    {
        StartCoroutine(TakePose());
    }

    private IEnumerator TakePose()
    {
        animation.Play(_currentClip.ToString());
        yield return new WaitForSecondsRealtime(_animationTime);
        animation.Stop();
    }

    private void OnTriggerExit(Collider other)
    {
        animation.Play("Idle");
    }

    public void NextAnimation(int animationIndex)
    {
        _currentClip = animationIndex;
        _animationTime = animation.GetClip(_currentClip.ToString()).length / 2;
        NextPose();
    }
}
