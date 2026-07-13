using UnityEngine;
// 네임 스페이스 가져오기
// 유니티 엔진이 제공하는 기능들(MonoBehaviour, GameObject, Debug 등)을 이 스크립트에서 사용하겠다고 선언하는 도구 상자입니다.

public class Delivery : MonoBehaviour 
// 딜리버리 클래스는 MonoBehaviour 를 상속 받아 만들어진다
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    // 이 구문은 hasPackageColor 변수는 Color32 를 유니티 에디터에서 변경 할 수 있게 hasPackageColor 라는 변수에
    // SerializeField(직렬화) 라는 [](속성)을 추가한다로 이해하면 됨.
    // 이 스크립트가 적용된 객체(오브젝트) 내의 인스펙터 내의 스크립트 컴포넌트 내에는 Has Package Color 필드(프로퍼티) 가 생긴다.
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start() 
    // 유니티 생명주기 메서드. 게임이 시작될 때 단 한 번만 실행되는 메서드로, 주로 컴포넌트를 가져오거나 초기값을 설정할 때 씁니다.
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // GetComponent는 "현재 오브젝트에서 컴포넌트 하나 가져와라!"라는 기능입니다.
        // 이때 어떤 종류의 컴포넌트를 가져올지에 대한 타입(<>)을 정하는 것
        // 현재 위에서는 현재 오브젝트에서 SpriteRenderer 타입 컴포넌트를 가져오라는 뜻이됨
    }

    void OnCollisionEnter2D(Collision2D other)
    // 충돌 영역에 부딪혔을 때 부딪힌 오브젝트를 전달함 관례적으로 other 사용
    {
        Debug.Log("마 자신있나");
        // 로그에 출력
    }

    void OnTriggerEnter2D(Collider2D other)
    // // 충돌 영역에 부딪혔을 때 트리거가 켜져있는 오브젝트의 경우 부딪힌 오브젝트를 전달함
    {
        // Debug.Log("뭐임시치");  
        if(other.tag == "Package" && !hasPackage)
        // 부딪힌 오브젝트의 태그가 패키지고, 지금 패키지를 안가지고 있다면
        {
            Debug.Log("패키지 픽업됨.");
            hasPackage = true;
            // 패키지 플래그 킴
            spriteRenderer.color = hasPackageColor;
            // 색을 변경
            Destroy(other.gameObject,destroyDelay);
            // other.gameObject를 쓸 수 있는 이유는 유니티가 이를 public으로 공개해 두었기 때문입니다.
            // Destroy는 다른 오브젝트의 private 영역을 해킹해 부수는 것이 아니라, 최고 관리자인 유니티 엔진에게 "이 오브젝트를 지워달라"고 합법적으로 요청하는 문법입니다.
        }

        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("고객 배달 완료.");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
