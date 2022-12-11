using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCam;
    public Transform portal;
    public Transform otherPortal;

    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCam.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;
        // new Vector3(-playerOffsetFromPortal.x, playerOffsetFromPortal.y , -playerOffsetFromPortal.z) ;

        transform.rotation = playerCam.rotation;

        // float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        // Quaternion portalRotationalDiffrance = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        // Vector3 newCameraDirection = portalRotationalDiffrance * playerCam.forward;
        // transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
