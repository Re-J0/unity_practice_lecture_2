using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // 이 물체(카메라)의 위치는 차의 위치와 같아야 한다
    [SerializeField] GameObject thingToFollow;

    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0,0,-10);
    }
}
