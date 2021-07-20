
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class PlayerController : MonoBehaviour
{  
    public Animation animation;

    public AnimationClip idleClip;


    void Awake()
    {
        animation = GetComponent<Animation>();

        idleClip.legacy = true;
        animation.AddClip(idleClip, "Idle");
        animation.Play("Idle");

        //for (int i = 0; i < animations.Length; i++)
        //{
        //    animations[i].legacy = true;
        //    animation.AddClip(animations[i], i.ToString());
        //}
    }

    public void NextPose(Pose pose)
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
