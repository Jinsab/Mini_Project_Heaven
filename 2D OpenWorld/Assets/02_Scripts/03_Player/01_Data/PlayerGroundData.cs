using System;
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
 *  1. 플레이어 지상 데이터
 *     - 기본 속도
 *     - 이동 속도
 *     - 달리기 속도
 *     
 *  [스크립트 작성 도움 출처]
 *  1. 
 */

[Serializable]
public class PlayerGroundData
{
    [field: SerializeField][field: Range(0f, 25f)] public float BaseSpeed { get; private set; } = 5f;

    [Header("IdleData")]

    [Header("WalkData")]
    [field: SerializeField][field: Range(0f, 2f)] public float WalkSpeedModifier { get; private set; } = 0.225f;

    [Header("RunData")]
    [field: SerializeField][field: Range(0f, 2f)] public float RunSpeedModifier { get; private set; } = 1f;
}