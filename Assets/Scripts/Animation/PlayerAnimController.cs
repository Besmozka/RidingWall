using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimController : MonoBehaviour
{
    private Animator _animator;

    private float animationTime;

    public float AnimationTime { get => animationTime; set => animationTime = value; }

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetInteger("AnimationState", (int)AnimationState.Idle);
    }

    public void NextPose(int animationIndex)
    {
        _animator.SetInteger("AnimationState", animationIndex);
        animationTime = TimeFromAnimation();
        StartCoroutine(TakePose());
    }

    private IEnumerator TakePose()
    {
        yield return new WaitForSecondsRealtime(animationTime);
        _animator.speed = 0;
    }
    
    public float TimeFromAnimation()
    {
        var currentStateInfo = _animator.GetCurrentAnimatorStateInfo(default);
        return currentStateInfo.length / 3;
    }

    private void OnTriggerExit(Collider other)
    {
            _animator.speed = 1;
            _animator.SetInteger("AnimationState", (int)AnimationState.Idle);
    }
}
