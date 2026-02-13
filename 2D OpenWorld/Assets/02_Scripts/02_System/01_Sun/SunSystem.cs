using UnityEngine;

/*  
 *  [프로젝트 제목]
 *  2D 오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.13 오후 13:56
 *  마지막 수정 일자 : 26.02.13 오후 14:08
 *  
 *  [스크립트 목적 및 내용]
 *  1. 태양 시스템 - 시간 계산
 *    1-1. 시간 흐름에 따른 태양 각도 계산
 *    
 *  [스크립트 작성 도움 출처]
 *  1. 
 */

public class SunSystem : MonoBehaviour
{
    public static SunSystem Instance;

    [Range(0f, 1f)]
    public float timeOfDay; // 0 = 자정, 0.5 = 정오

    public float dayDuration = 300f; // 하루 길이 (초)

    public float sunAngle;   // 현재 태양 각도
    public Vector2 sunDirection; // 그림자 계산용 방향

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        UpdateTime();
        UpdateSun();
    }

    private void UpdateTime()
    {
        timeOfDay += Time.deltaTime / dayDuration;
        if (timeOfDay > 1f)
            timeOfDay -= 1f;
    }

    private void UpdateSun()
    {
        // -90 ~ 270도 회전
        sunAngle = timeOfDay * 360f - 90f;

        float rad = sunAngle * Mathf.Deg2Rad;

        sunDirection = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        sunDirection.Normalize();
    }

    public float GetSunHeight()
    {
        // 태양 고도 (0~1)
        return Mathf.Clamp01(Mathf.Sin(timeOfDay * Mathf.PI));
    }
}
