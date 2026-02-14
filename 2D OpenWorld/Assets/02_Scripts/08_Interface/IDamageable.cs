using UnityEngine;

/*  
 *  [프로젝트 제목]
 *  2D 오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.14 오후 17:53
 *  마지막 수정 일자 : 26.02.14 오후 17:53
 *  
 *  [스크립트 목적 및 내용]
 *  1. 채집 인터페이스
 *    1-1. 모든 데미지 대상의 공통 구조
 *    1-2. 나무, 돌, 광석, 몬스터 등 전부 동일한 구조로 처리하기 위함
 *     
 *  [스크립트 작성 도움 출처]
 *  1. 
 */

public interface IDamageable
{
    void TakeDamage(int amount, GameObject attacker);
}