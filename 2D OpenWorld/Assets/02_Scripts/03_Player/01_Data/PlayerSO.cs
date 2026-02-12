using UnityEngine;

/*  
 *  [프로젝트 제목]
 *  2D 오픈월드 생존제작
 *             
 *  [프로젝트 일자]
 *  파일 생성 일자 : 26.02.12 오후 20:53
 *  마지막 수정 일자 : 26.02.12 오후 20:53
 *  
 *  [스크립트 목적 및 내용]
 *  1. 플레이어 이동 데이터
 *     
 *  [스크립트 작성 도움 출처]
 *  1. 
 */

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundData GroundedData { get; private set; }
}