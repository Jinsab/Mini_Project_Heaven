using UnityEngine;
using UnityEngine.Rendering.Universal;

/*  
 *  [프로젝트 제목]
 *  2D 오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.13 오후 14:03
 *  마지막 수정 일자 : 26.02.13 오후 14:09
 *  
 *  [스크립트 목적 및 내용]
 *  1. 태양 시스템 - 카메라 중심 조명
 *    1-1. 낮에는 전역 조명(Global Light 2D)을 사용함 (밤이 될수록 값[효과]이 작아짐)
 *    1-2. 전역 조명은 원점이 없기 때문에 장면의 모든 스프라이트를 균등하게 비추게 됨
 *    1-3. 따라서 햇빛 효과를 구현하기 위해서 약간의 트릭이 필요함
 *    1-4. 월드의 객체만 대상으로 하는 추가 렌더링 레이어를 만듬
 *    1-5. 이후, 카메라를 중심으로 회전
 *    1-6. 시야에 있는 객체를 강조하는 스프라이트 조명이 필요했음
 *    
 *  [스크립트 작성 도움 출처]
 *  1. https://youtu.be/UavoVWHrebM?si=e9L-nRSkLxdkAE0W
 */

public class SunHighlightLight : MonoBehaviour
{
    public Transform cameraTarget;
    public Light2D sunLight;

    void LateUpdate()
    {
        if (cameraTarget == null)
            return;

        transform.position = cameraTarget.position;

        float angle = Mathf.Atan2(
            SunSystem.Instance.sunDirection.y,
            SunSystem.Instance.sunDirection.x
        ) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
