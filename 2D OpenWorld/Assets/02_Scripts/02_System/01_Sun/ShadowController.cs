using UnityEngine;

/*  
 *  [프로젝트 제목]
 *  2D 오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.13 오후 14:37
 *  마지막 수정 일자 : 26.02.13 오후 14:09
 *  
 *  [스크립트 목적 및 내용]
 *  1. 태양 시스템 - 낮과 밤
 *    1-1. 전체 밝기 제어는 Global Light 2D로 진행됨
 *    1-2. 따라서, 시간 흐름에 따라 밝기를 제어하여 낮과 밤을 구분
 *    
 *  [스크립트 작성 도움 출처]
 *  1. 
 */

[RequireComponent(typeof(SpriteRenderer))]
public class ShadowController : MonoBehaviour
{
    [Header("Shadow Settings")]
    public float shadowLengthMultiplier = 1.5f;
    public float minLengthFactor = 0.3f;
    public float maxLengthFactor = 1.8f;
    public float positionPower = 0.25f;

    private SpriteRenderer shadowRenderer;
    private SpriteRenderer parentRenderer;
    private Transform parentTransform;

    private float spriteHeight;

    void Awake()
    {
        shadowRenderer = GetComponent<SpriteRenderer>();
        parentTransform = transform.parent;
        parentRenderer = parentTransform.GetComponent<SpriteRenderer>();

        InitializeShadow();
    }

    void InitializeShadow()
    {
        // 부모 스프라이트 복사
        shadowRenderer.sprite = parentRenderer.sprite;

        // 실제 스프라이트 월드 높이
        spriteHeight = parentRenderer.bounds.size.y;

        shadowRenderer.color = new Color(0, 0, 0, 0.5f);

        // 같은 SortingLayer 사용 권장
        shadowRenderer.sortingLayerID = parentRenderer.sortingLayerID;
        shadowRenderer.sortingOrder = parentRenderer.sortingOrder - 1;

        transform.localPosition = Vector3.zero;
    }

    void LateUpdate()
    {
        UpdateShadow();
    }

    void UpdateShadow()
    {
        Vector2 sunDir = SunSystem.Instance.sunDirection;

        Vector3 bottomPoint =
            parentRenderer.bounds.center
            - new Vector3(0, parentRenderer.bounds.extents.y, 0);

        transform.position = bottomPoint;

        Vector2 shadowDir = -sunDir;

        float angle = Mathf.Atan2(
            shadowDir.y,
            shadowDir.x
        ) * Mathf.Rad2Deg;

        transform.rotation =
            Quaternion.Euler(0, 0, angle);

        transform.localScale = Vector3.one;
    }
}
