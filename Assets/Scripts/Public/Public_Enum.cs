using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Public_Enum : BaseMonoBehaviour
{
    // ============================================[�鿪���� ������]=================================================

    private IOverallManager _overallManager;

    public IOverallManager _OverallManager
    {
        get { return _overallManager; }
    }

    public void Init(IOverallManager overallManager)
    {
        _overallManager = overallManager;
    }

    // ============================================[�迪���� ������]=================================================

    // ============================================[����� Enum ������]=================================================


    public enum PlayerState         //�÷��̾� ����
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
        Cold,         // 1~50: ���� ��� ����
        Unstable,     // 51~70: ���� �Ҿ����� ����
        Violent,      // 71~80: �������� �ൿ�� �ϴ� ����. 30% Ȯ���� ���� ������
        ZombieLike,           // 81~90: ����� ������ ����. 50% Ȯ���� ���� ������
        AlmostZombie,         // 90~99: ���� ����� ������ �� ���� ����. 100% Ȯ���� ���� ������
        Zombie // 100: ����ȭ �Ϸ�. ����ų �� ����
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

    // ============================================[����� Enum ������]=================================================
}
