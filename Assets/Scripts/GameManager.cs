using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class GameManager : MonoBehaviour
{    
    [SerializeField]
    private WallManager _wallManager;
    [SerializeField]
    private PoseManager _poseManager;
    [SerializeField]
    private GestureManager _gestureManager;
    [SerializeField]
    private PlayerController _player;    
    [SerializeField]
    private PlayerController _playerGhost;

    private Pose _pose;


    public void Start()
    {
        _gestureManager.WinEvent += Win;
        _gestureManager.FailEvent += Fail;

        StartCoroutine(NewPose());
    }

    private IEnumerator NewPose()
    {
        _pose = _poseManager.GetPose();
        _playerGhost.NextPose(_pose);
        yield return new WaitForSecondsRealtime(_pose.AnimationTime);
        _gestureManager.NextGesturePattern();
        _wallManager.CreateNewWall();
    }

    private void Win()
    {
        _player.NextPose(_pose);
    }

    private void Fail()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            _wallManager.DestroyWall();
            StartCoroutine(NewPose());
        }
    }
}
