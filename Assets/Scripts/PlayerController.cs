
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class PlayerController : MonoBehaviour
{  
    private Animation animationComponent;

    public AnimationClip idleClip;

    private Pose _currentPose;


    void Awake()
    {
        animationComponent = GetComponent<Animation>();
        animationComponent.playAutomatically = false;

        idleClip.legacy = true;
        animationComponent.AddClip(idleClip, "Idle");
        animationComponent.Play("Idle");
    }

    public void NextPose(Pose pose)
    {
        _currentPose = pose;
        StartCoroutine(TakePose());
    }

    private IEnumerator TakePose()
    {
        animationComponent.Play(_currentPose.AnimationClip.ToString());
        yield return new WaitForSeconds(_currentPose.AnimationTime);
        animationComponent.Stop();
    }

    private void OnTriggerExit(Collider other)
    {
        animationComponent.Play("Idle");
    }
}
