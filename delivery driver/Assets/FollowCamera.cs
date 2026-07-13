using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // 이 물체(카메라)의 위치는 차의 위치와 같아야 한다
    [SerializeField] GameObject thingToFollow;

    void LateUpdate() 
    // 유니티 생명주기 메서드 매 프레임마다 반복해서 실행되는 메서드입니다.
    {
        transform.position = thingToFollow.transform.position + new Vector3(0,0,-10);
        // 유니티 2D 는 사실 3D 공간을 평면으로 나타낸것.
        // 카메라의 Z축이 차의 Z축과 동일할 경우, 카메라는 자기와 겹쳐있거나 바로앞,뒤 물체는 렌저 클리핑 현상 때문에 그리지 못함.
        // 따라서 카메라가 뒤로 물러나 정면으로 관측할 수 있게 -10을 해줌.
    }
}
