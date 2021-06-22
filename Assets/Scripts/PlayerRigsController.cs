using UnityEngine;

public class PlayerRigsController : MonoBehaviour
{
    private float changePositionSpeed = 3f;

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


    private void MoveLeftArm(Transform point)
    {
        leftArmTarget.transform.Translate(point.position * changePositionSpeed * Time.fixedDeltaTime);
    }

    private void MoveRigthArm(Transform point)
    {
        rigthArmTarget.transform.Translate(point.position * changePositionSpeed * Time.fixedDeltaTime);
    }

    private void MoveLeftLeg(Transform point)
    {
        leftLegTarget.transform.Translate(point.position * changePositionSpeed * Time.fixedDeltaTime);
    }

    private void MoveRigthLeg(Transform point)
    {
        rigthLegTarget.transform.Translate(point.position * changePositionSpeed * Time.fixedDeltaTime);
    }
}

