using UnityEngine;

/*  
 *  [프로젝트 제목]
 *  오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.12 오후 15:10
 *  마지막 수정 일자 : 26.02.12 오후 15:43
 *  
 *  [스크립트 목적 및 내용]
 *  1. 플레이어 상태 머신
 *    1-1. 애니메이션 관리
 *    
 *  2. 큰 그림
 *    - Player (GameObject)
 *      ├─ PlayerController    // 입력 & 상태 조율 (두뇌)
 *      ├─ PlayerMovement      // 이동 / 회전
 *      ├─ PlayerInteraction   // 상호작용
 *      ├─ PlayerEquipment     // 장비 시스템
 *      ├─ PlayerCombat        // 전투 시스템
 *      │  ├─ CombatController // 공격 로직 관리
 *      │  └─ WeaponController // 무기 장착 관리
 *      │
 *      ├─ PlayerHealth        // (IDamageable) 체력 / 피격 / 사망
 *      ├─ PlayerStats         // 세부 스탯 (기력 등)
 *      ├─ Inventory           // 아이템 수집 / 관리
 *      ├─ PlayerItemUser      // 아이템 사용
 *      ├─ EffectController    // (구현 예정) 효과 적용
 *      ├─ PlayerAnimation     // Animator 제어
 *      ├─ PlayerStateMachine  // 상태 관리
 *      └─ PlayerAudio / VFX   // (선택)
 *     
 *  [스크립트 작성 도움 출처]
 *  1. 
 */

public enum PlayerState
{
    Idle,
    Walk,
    Run
}

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerController Player { get; private set; }

    public PlayerState CurrentState { get; private set; }

    public void Initialize()
    {
        Player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Player.PlayerMovement.MoveInput == Vector2.zero)
        {
            ChangeState(PlayerState.Idle);
        }
        else
        {
            if (Player.PlayerMovement.IsRunning)
                ChangeState(PlayerState.Run);
            else
                ChangeState(PlayerState.Walk);
        }
    }

    void ChangeState(PlayerState newState)
    {
        if (CurrentState == newState) return;
        CurrentState = newState;
    }
}
