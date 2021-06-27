using UnityEngine;

public class PlayerRigsController : MonoBehaviour
{
    public float changePositionSpeed = 3f;

    float armMinY = -4f;
    float armMaxY = 4f;
    float armMaxX = 1;
    float legMaxY = 1;
    float legMaxX = 2;
    float legMaxZ = 1;

    [SerializeField]
    private GameObject leftArmTarget;
    [SerializeField]
    private GameObject rigthArmTarget;
    [SerializeField]
    private GameObject leftHandTarget;
    [SerializeField]
    private GameObject rigthHandTarget;
    [SerializeField]
    private GameObject leftLegTarget;
    [SerializeField]
    private GameObject rigthLegTarget;

    public PlayerPose playerPose;


    private void Update()
    {
        if (playerPose != null)
        {
            SetPose(playerPose);
        }
    }


    public void SetPose(PlayerPose pose)
    {
        MoveRig(pose.LeftArmPoint, leftLegTarget);
        MoveRig(pose.RigthArmPoint, leftArmTarget);
        MoveRig(pose.LeftLegPoint, rigthLegTarget);
        MoveRig(pose.RigthLegPoint, rigthArmTarget);
    }

    private void MoveRig(Vector3 point, GameObject rig)
    {
        rig.transform.localPosition = Vector3.MoveTowards(rig.transform.localPosition, point, Time.deltaTime * changePositionSpeed);
    }

    public void ResetPose()
    {
        leftArmTarget.transform.localPosition = Vector3.zero;
        rigthArmTarget.transform.localPosition = Vector3.zero;
        leftHandTarget.transform.localPosition = Vector3.zero;
        rigthHandTarget.transform.localPosition = Vector3.zero;
        leftLegTarget.transform.localPosition = Vector3.zero;
        rigthLegTarget.transform.localPosition = Vector3.zero;
        playerPose = null;
    }

    public PlayerPose NewPose()
    {
        Vector3 leftArmPoint = new Vector3
        {
            x = -Random.Range(0, armMaxX),
            y = Random.Range(armMinY, armMaxY),
            z = 0
        };

        Vector3 rigthArmPoint = new Vector3
        {
            x = Random.Range(0, armMaxX),
            y = Random.Range(armMinY, armMaxY),
            z = 0
        };

        Vector3 leftLegPoint = Vector3.zero;
        Vector3 rigthLegPoint = Vector3.zero;

        if (Random.Range(-1, 1) >= 0)
        {
            leftLegPoint = new Vector3
            {
                x = -Random.Range(0f, legMaxX),
                y = Random.Range(0f, legMaxY),
                z = Random.Range(0, legMaxZ)
            };
        }
        else
        {
            rigthLegPoint = new Vector3
            {
                x = Random.Range(0f, legMaxX),
                y = Random.Range(0f, legMaxY),
                z = Random.Range(0, legMaxZ)
            };
        }

        PlayerPose playerPose = new PlayerPose(leftArmPoint, rigthArmPoint, leftLegPoint, rigthLegPoint, leftArmPoint, rigthArmPoint);
        return playerPose;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            ResetPose();
        }
    }
}

