using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimController : MonoBehaviour
{
    private Animator _animator;

    private float _percentage = 4f;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetInteger("AnimationState", (int)AnimationState.Idle);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(TakePose());
        }
    }

    private IEnumerator TakePose()
    {
        var animationState = Random.Range(1, 5);
        _animator.SetInteger("AnimationState", animationState);

        var currentStateInfo = _animator.GetCurrentAnimatorStateInfo(default);
        var poseTime = TimeForPoseFromAnimation(currentStateInfo);

        yield return new WaitForSeconds(poseTime);
        _animator.speed = 0;
    }
    
    private float TimeForPoseFromAnimation(AnimatorStateInfo animation)
    {
        var deltaTime = animation.length / _percentage;
        var stopTimePoint = Random.Range(deltaTime, animation.length - deltaTime);
        return stopTimePoint;
    }
}
