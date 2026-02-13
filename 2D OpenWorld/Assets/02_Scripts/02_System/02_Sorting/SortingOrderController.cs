using UnityEngine;

/*  
 *  [프로젝트 제목]
 *  2D 오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.13 오후 18:09
 *  마지막 수정 일자 : 26.02.13 오후 18:10
 *  
 *  [스크립트 목적 및 내용]
 *  1. Position Y 값에 따른 Sorting Order 변경 스크립트
 *    1-1. Y 값에 따라 SortingOrder 변경
 *     
 *  [스크립트 작성 도움 출처]
 *  1. https://www.youtube.com/watch?v=1CPQzoYFMog
 */

[RequireComponent(typeof(SpriteRenderer))]
public class SortingOrderController : MonoBehaviour
{
    public int precision = 100;

    private SpriteRenderer sr;
    private int lastOrder;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateSorting();
    }

    public void UpdateSorting()
    {
        int newOrder = -(int)(transform.position.y * precision);

        if (newOrder != lastOrder)
        {
            sr.sortingOrder = newOrder;
            lastOrder = newOrder;
        }
    }
}