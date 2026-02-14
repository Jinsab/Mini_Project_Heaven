/*  
 *  [프로젝트 제목]
 *  2D 오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.14 오후 17:55
 *  마지막 수정 일자 : 26.02.14 오후 21:26
 *  
 *  [스크립트 목적 및 내용]
 *  1. 아이템 시스템 - 드랍 데이터
 *    1-1. 드랍 테이블의 기본적인 클래스
 *    1-2. 나중 확장을 위해 분리하였음
 *    
 *  2. 큰 그림
 *    - Item (ScriptableObject)
 *      ├─ ItemData (기본 정보)
 *      ├─ ItemDatabase (데이터베이스)
 *      ├─ (Type)Item (아이템 타입)
 *      │  ├─ ConsumableItem (소비 아이템)
 *      │  └─ ToolItem (도구 아이템)
 *      │
 *      ├─ ItemDropSpawner
 *      ├─ ItemDrop
 *      ├─ DropTable
 *      └─ DropData
 *      
 *  [스크립트 작성 도움 출처]
 *  1. 
 */

[System.Serializable]
public class DropData
{
    public Item item;
    public int minAmount = 1;
    public int maxAmount = 3;
    [UnityEngine.Range(0f, 1f)]
    public float dropChance = 1f;
}