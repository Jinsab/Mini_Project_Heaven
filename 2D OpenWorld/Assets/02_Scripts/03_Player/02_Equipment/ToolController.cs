using UnityEngine;

/*  
 *  [프로젝트 제목]
 *  2D 오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.14 오후 21:15
 *  마지막 수정 일자 : 26.02.14 오후 21:21
 *  
 *  [스크립트 목적 및 내용]
 *  1. 장비 시스템 - 도구
 *    1-1. 도구 사용 부분 구현
 *    1-2. 특정 범위를 그리고, 해당 위치에 해당하는 개체에 데미지를 입힘
 *     
 *  [스크립트 작성 도움 출처]
 *  1. 
 */

public class ToolController : MonoBehaviour
{
    public float range = 1.5f;

    public void UseTool(ToolItem tool)
    {
        Collider2D hit = Physics2D.OverlapCircle(
            transform.position,
            range
        );

        if (hit == null) return;

        IDamageable damageable = hit.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(tool.power, gameObject);
        }
    }
}