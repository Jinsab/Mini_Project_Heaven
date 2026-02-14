using UnityEngine;

/*  
 *  [프로젝트 제목]
 *  2D 오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.13 오후 20:46
 *  마지막 수정 일자 : 26.02.14 오후 17:45
 *  
 *  [스크립트 목적 및 내용]
 *  1. 아이템 스크립트
 *    1-1. 아이템 
 *    1-2. 인벤토리 아이템 추가
 *    1-3. 인벤토리 아이템 제거
 *    
 *  2. 큰 그림
 *    - Item (ScriptableObject)
 *      ├─ ItemData (기본 정보)
 *      ├─ EquipmentItem (장비 아이템)
 *      ├─ ConsumableItem (소비 아이템)
 *      └─ QuestItem
 *      
 *    - Effect (ScriptableObject)
 *      ├─ StatModifierEffect
 *      ├─ HealOverTimeEffect
 *      └─ BuffEffect
 *  
 *  [스크립트 작성 도움 출처]
 *  1. 
 */

public abstract class Item : ScriptableObject
{
    public enum ItemType
    {
        Resource,     // 원자재
        Material,     // 가공 재료
        Equipment,    // 장착 아이템 (무기/도구/방어구)
        Consumable,   // 사용 즉시 효과
        Placeable,    // 설치 아이템
        Quest,        // 퀘스트 전용
    }

    [Header("# Item Info")]
    public string itemName;             // 아이템 이름
    public int itemId;                  // 아이템 고유 아이디 (중복될 수 없음)
    [TextArea] public string itemDesc;  // 아이템 설명
    public Sprite Icon;                 // 아이템 아이콘

    public ItemType itemType;           // 아이템 타입

    [Header("# Item Stack")]
    public int maxStack = 1;            // 최대 스택 갯수 (1 == 비스택)

    public bool isDroppable = true;     // 버리기 시스템
    public bool isDestroyable = true;   // 버리기 시스템

    public int buyPrice;                // 상점 시스템
    public int sellPrice;               // 상점 시스템

    public abstract void Use(GameObject user);
}