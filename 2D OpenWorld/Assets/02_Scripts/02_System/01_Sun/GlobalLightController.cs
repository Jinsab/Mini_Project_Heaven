using UnityEngine;
using UnityEngine.Rendering.Universal;

/*  
 *  [프로젝트 제목]
 *  2D 오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.13 오후 14:37
 *  마지막 수정 일자 : 26.02.13 오후 14:37
 *  
 *  [스크립트 목적 및 내용]
 *  1. 태양 시스템 - 낮과 밤
 *    1-1. 전체 밝기 제어는 Global Light 2D로 진행됨
 *    1-2. 따라서, 시간 흐름에 따라 밝기를 제어하여 낮과 밤을 구분
 *    
 *  [스크립트 작성 도움 출처]
 *  1. 
 */

public class GlobalLightController : MonoBehaviour
{
    public Light2D globalLight;

    public Color dayColor = Color.white;
    public Color nightColor = new Color(0.1f, 0.15f, 0.25f);

    void Update()
    {
        float height = SunSystem.Instance.GetSunHeight();

        globalLight.color = Color.Lerp(nightColor, dayColor, height);
        globalLight.intensity = Mathf.Lerp(0.2f, 1f, height);
    }
}
