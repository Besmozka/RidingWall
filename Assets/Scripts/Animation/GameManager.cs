using GestureRecognizer;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class GameManager : MonoBehaviour
{    
    [SerializeField]
    private LevelsManager _levelsManager;
    [SerializeField]
    private PoseManager _poseManager;
    [SerializeField]
    private GestureController _gestureController;

    private PlayerController _player;
    private PlayerController _playerGhost;

    private Pose _pose;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            _levelsManager.NextWall();
            Destroy(other.gameObject);
        }
    }

    public void StartGame()
    {
        _pose = _poseManager.GetPose();
        _levelsManager.NextWall();
        _player.NextPose(_pose);
        _playerGhost.NextPose(_pose);
    }
}
