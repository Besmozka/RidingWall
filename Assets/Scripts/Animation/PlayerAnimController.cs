
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
        idleClip.legacy = true;
        animation.AddClip(idleClip, "Idle");
        for (int i = 0; i < animations.Length; i++)
        {
            animations[i].legacy = true;
            animation.AddClip(animations[i], i.ToString());
        }
        animation.Play("Idle");
    }

    public void NextPose()
    {
        StartCoroutine(TakePose());
    }

    private IEnumerator TakePose()
    {
        animation.Play(_currentClip.ToString());
        yield return new WaitForSeconds(_animationTime);
        animation.Stop();
    }

    private void OnTriggerExit(Collider other)
    {
        animation.Play("Idle");
    }

    public void NextAnimation(int animationIndex, float animationTime)
    {
        _currentClip = animationIndex;
        _animationTime = animationTime;
    }
}
