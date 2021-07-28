using GestureRecognizer;
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
    private GestureManager _gestureController;
    [SerializeField]
    private PlayerController _player;    
    [SerializeField]
    private PlayerController _playerGhost;

    private Pose _pose;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            _wallManager.DestroyWall();
        }
    }

    public void Start()
    {
        _pose = _poseManager.GetPose();
        _wallManager.CreateNewWall();
        _player.NextPose(_pose);
        _playerGhost.NextPose(_pose);
    }
}
