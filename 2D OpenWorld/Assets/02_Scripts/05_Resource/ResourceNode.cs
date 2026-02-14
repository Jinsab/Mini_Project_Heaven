using UnityEngine;

/*  
 *  [프로젝트 제목]
 *  2D 오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.14 오후 17:54
 *  마지막 수정 일자 : 26.02.14 오후 17:54
 *  
 *  [스크립트 목적 및 내용]
 *  1. 채집 노드 (채집 가능한 오브젝트의 기본 클래스)
 *    1-1. 모든 데미지 대상의 공통 구조
 *    1-2. 나무, 돌, 광석, 몬스터 등 전부 동일한 구조로 처리하기 위함
 *     
 *  [스크립트 작성 도움 출처]
 *  1. 
 */

public class ResourceNode : MonoBehaviour, IDamageable
{
    [Header("Resource Info")]
    public int maxHP = 5;

    [Header("Drop Table")]
    public DropTable dropTable;

    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int amount, GameObject attacker)
    {
        currentHP -= amount;

        if (currentHP <= 0)
        {
            Harvest();
        }
    }

    private void Harvest()
    {
        dropTable.Drop(transform.position);
        Destroy(gameObject);
    }
}
