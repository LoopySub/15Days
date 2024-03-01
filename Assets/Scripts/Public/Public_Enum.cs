using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Public_Enum : BaseMonoBehaviour
{
    // ============================================[↓역참조 구역↓]=================================================

    private IOverallManager _overallManager;

    public IOverallManager _OverallManager
    {
        get { return _overallManager; }
    }

    public void Init(IOverallManager overallManager)
    {
        _overallManager = overallManager;
    }

    // ============================================[↑역참조 구역↑]=================================================

    // ============================================[↓공용 Enum 구역↓]=================================================


    public enum PlayerState         //플레이어 상태
    {
        Idle,
        Walking,
        Running,
        Jumping
    }

    public enum GameState
    {
        Playing,
        Interface_On,
        Cutscene,
    }

    public enum RebeccaStatus
    {
        Cold,         // 1~50: 감기 기운 상태
        Unstable,     // 51~70: 조금 불안정한 상태
        Violent,      // 71~80: 폭력적인 행동을 하는 상태. 30% 확률로 존을 공격함
        ZombieLike,           // 81~90: 좀비와 유사한 상태. 50% 확률로 존을 공격함
        AlmostZombie,         // 90~99: 거의 좀비와 구분할 수 없는 상태. 100% 확률로 존을 공격함
        Zombie // 100: 좀비화 완료. 돌이킬 수 없음
    }

    public enum Ending_type
    {
        GameOver,
        Infection,
        Starvation,
        Normal,
        True
    }

    public enum Icon_type
    {
        Null,
        Jone,
        Rebecca
    }

    // ============================================[↑공용 Enum 구역↑]=================================================
}
