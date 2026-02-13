using UnityEngine;

/*  
 *  [프로젝트 제목]
 *  2D 오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.13 오후 18:09
 *  마지막 수정 일자 : 26.02.13 오후 18:11
 *  
 *  [스크립트 목적 및 내용]
 *  1. 사물 범위에 접촉할 때, 반투명하게 만들어주는 스크립트
 *    1-1. Tag 및 Trigger를 사용한 구현
 *     
 *  [스크립트 작성 도움 출처]
 *  1. 
 */

public class FadeController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color originalColor;

    [Header(" # Fade Alpha")]
    [Tooltip("값이 높아질수록 투명도가 높아집니다.")]
    public float fadeAlpha = 0.5f;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, fadeAlpha);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sr.color = originalColor;
        }
    }
}