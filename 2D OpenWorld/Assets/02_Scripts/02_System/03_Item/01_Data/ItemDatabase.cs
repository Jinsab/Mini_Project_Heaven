using UnityEngine;
using System.Collections.Generic;

/*  
 *  [프로젝트 제목]
 *  2D 오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.13 오후 20:46
 *  마지막 수정 일자 : 26.02.14 오후 21:21
 *  
 *  [스크립트 목적 및 내용]
 *  1. 아이템 스크립트 - 아이템 데이터베이스
 *    1-1. ItemID로 Item을 찾기 위한 스크립트
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

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance;

    public List<Item> allItems;

    private Dictionary<int, Item> itemDict;

    void Awake()
    {
        Instance = this;

        itemDict = new Dictionary<int, Item>();

        foreach (var item in allItems)
        {
            itemDict[item.itemId] = item;
        }
    }

    public Item GetItem(int id)
    {
        if (itemDict.TryGetValue(id, out Item item))
            return item;

        return null;
    }
}
