using UnityEngine;

/*  
 *  [프로젝트 제목]
 *  2D 오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.14 오후 18:20
 *  마지막 수정 일자 : 26.02.14 오후 18:20
 *  
 *  [스크립트 목적 및 내용]
 *  1. 아이템 시스템 - 아이템 스폰 중앙 관리
 *    1-1. 드롭 아이템 소환
 *     
 *  [스크립트 작성 도움 출처]
 *  1. 
 */

public class ItemDropSpawner : MonoBehaviour
{
    public static ItemDropSpawner Instance;

    public GameObject itemDropPrefab;

    void Awake()
    {
        Instance = this;
    }

    public void Spawn(Item item, int amount, Vector3 position)
    {
        GameObject obj = Instantiate(
            itemDropPrefab,
            position,
            Quaternion.identity
        );

        ItemDrop drop = obj.GetComponent<ItemDrop>();
        drop.Initialize(item, amount);
    }
}