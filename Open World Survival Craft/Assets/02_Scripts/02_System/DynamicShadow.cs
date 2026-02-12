using UnityEngine;

public class DynamicShadow : MonoBehaviour
{
    public Transform target;              // 플레이어
    public Light directionalLight;        // 태양
    public float shadowDistance = 1.5f;   // 기본 거리
    public float shadowHeightInfluence = 0.5f; // 태양 고도 영향

    void LateUpdate()
    {
        if (directionalLight == null || target == null)
            return;

        Vector3 lightDir = directionalLight.transform.forward;

        // 그림자는 빛의 반대 방향
        Vector3 shadowDir = -lightDir;
        shadowDir.y = 0;
        shadowDir.Normalize();

        // 태양이 낮을수록 그림자 길게
        float sunHeight = Mathf.Clamp01(lightDir.y);
        float dynamicLength = shadowDistance * (1f - sunHeight + shadowHeightInfluence);

        Vector3 shadowPos = target.position + shadowDir * dynamicLength;

        // 바닥에 고정
        shadowPos.y = 0.01f;

        transform.position = shadowPos;
    }
}
