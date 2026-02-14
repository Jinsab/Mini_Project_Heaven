using System.Collections.Generic;
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
 *  1. 인벤토리 시스템 - 슬롯 단위 인벤토리
 *    1-1. 플레이어, 창고, 화로(용광로), 그 외 작업대 등에 입혀 사용할 수 있음
 *     
 *  [스크립트 작성 도움 출처]
 *  1. 
 */

[System.Serializable]
public class InventorySlot
{
    public int itemId;
    public int amount;

    // 런타임 전용 (저장 안 됨)
    [System.NonSerialized]
    public Item item;
}

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> slots;
    private List<InventorySlot> sameItemSlot;

    public int maxSlots = 20;

    private void Awake()
    {
        slots = new List<InventorySlot>(maxSlots);
        sameItemSlot = new List<InventorySlot>(maxSlots);
    }

    // 아이템 스택 추가 후 몇 개 넣었는 지를 반환하기.
    public int AddItem(Item item, int amount)
    {
        int added = 0;
        // 동일한 아이템이 있는가 없는가
        // 있다면 스택 처리를 해야 함
        // 없다면 가장 마지막 자리에 추가하면 됨

        // 아이템을 수집할 수 있는지 확인
        if (CanAdd(item, amount))
        {
            List<InventorySlot> addItemSlot = slots.FindAll(slot => slot.item.itemId.Equals(item.itemId) && slot.amount != slot.item.maxStack); ;

            // 같은 ID를 가진 아이템 리스트를 순회하며 아이템 추가
            foreach (var slot in addItemSlot)
            {
                // 모든 아이템 스택을 추가하였다면 빠져나오기
                if (amount <= 0)
                    return amount;

                // 최대 스택 수를 넘지 않는가?
                if (slot.amount + amount <= item.maxStack)
                {
                    slot.amount += amount;
                    Debug.Log($"동일한 아이템 스택 처리 {item.itemName} {amount}개 저장");
                    return amount;
                }
                else
                {
                    // 더 추가할 수 있는 스택 수
                    // 최대 10개, 현재 7개, 5개 더 있다 치면 남은 갯수는 3임
                    int spaceLeft = slot.item.maxStack - slot.amount;

                    added += spaceLeft;
                    slot.amount += spaceLeft;

                    Debug.Log($"동일한 아이템 스택 처리 {item.itemName} {spaceLeft}개 저장 및 다음 슬롯에 {amount - added}개 넘기기");
                }
            }
        }

        // 스택 처리 후 인벤토리가 꽉 찼다면 공간 부족으로 false
        if (IsFull())
            return added;

        // 스택은 모두 쌓였고 인벤토리에 더 넣을 공간이 있다면
        // maxStack보다 작을 때는 그냥 추가하고,
        // maxStack보다 크다면 maxStack 값을 넣으며 값 반환

        // 인벤토리에 동일한 아이템이 없음
        // 아이템의 개수가 개수 제한을 초과한 횟수만큼 반복
        for (int i = 0; i <= amount / item.maxStack; i++)
        {
            // 현재 아이템의 개수가 maxStack 초과한 경우
            if (amount - added > item.maxStack)
            {
                slots.Add(new InventorySlot { item = item, amount = item.maxStack });
                added += item.maxStack;
                Debug.Log($"인벤토리에 {item.itemName} {item.maxStack}개 저장" +
                          $"\n초과 분량: {amount - added}");
            }
            // 현재 아이템의 개수가 maxStack 이하인 경우
            else
            {
                slots.Add(new InventorySlot { item = item, amount = amount - added });
                Debug.Log($"인벤토리에 {item.itemName} {amount - added}개 저장");
                return amount;
            }

            // 인벤토리가 꽉 찼다면 공간 부족으로 반환
            if (IsFull())
                return added;
        }

        // 아이템을 전부 넣은 경우
        return amount;
    }

    public bool CanAdd(Item item, int amount)
    {
        // 스택 가능 여부, 빈 슬롯 확인
        if (item.maxStack > 1)
        {
            sameItemSlot = slots.FindAll(slot => slot.item.itemId.Equals(item.itemId) && slot.amount != slot.item.maxStack);

            if (sameItemSlot.Count > 0)
            {
                int totalAvailableSpace = 0;

                // 같은 ID를 가진 아이템을 순회하며 남은 공간 계산
                foreach (var slot in sameItemSlot)
                {
                    totalAvailableSpace += (item.maxStack - slot.amount);
                }

                // 아이템을 일부라도 수집할 수 있다면 true 반환
                if (totalAvailableSpace > 0)
                {
                    return true;
                }
            }
        }

        // 스택이 불가능하다면, 빈 슬롯만 확인하여 결과 값 반환
        return !IsFull();
    }

    public void RemoveItem(Item item, int amount)
    {

    }

    public bool IsFull()
    {
        return slots.Count >= maxSlots;
    }
}
