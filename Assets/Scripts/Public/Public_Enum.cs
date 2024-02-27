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
    public enum DifficultyLevel     //난이도 레벨
    {
        Easy,
        Normal,
        Hard
    }
    public enum QuestType       // 퀘스트 유형
    {
        Main,
        Side,
        Daily
    }
    public enum ItemType         // 아이템 유형
    {
        Weapon,
        Armor,
        Consumable,
        QuestItem
    }
    public enum UIState        // UI 상태
    {
        MainMenu,
        InGame,
        PauseMenu,
        GameOver

    }
    public enum PlatformType        // 플랫폼 유형
    {
        PC,
        Console,
        Mobile

    }
    // ============================================[↑공용 Enum 구역↑]=================================================
}
