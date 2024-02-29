using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameDataManager : BaseMonoBehaviour    // 게임 데이터를 직접적으로 관리하는 메서드와 동작들이 있는 스크립트
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
    // =======================================[↓게임 데이터 메소드 구역↓]==========================================
    // 취침 시 배부름에 따른 스태미나 회복량 계산
    public void RecoverStaminaAfterSleep()
    {
        if (OverallManager.Instance.PublicVariable.Fullness >= 100)
            OverallManager.Instance.PublicVariable.Stamina = 120.0f;
        else if (OverallManager.Instance.PublicVariable.Fullness >= 75)
            OverallManager.Instance.PublicVariable.Stamina = 100.0f;
        else
            OverallManager.Instance.PublicVariable.Stamina = (OverallManager.Instance.PublicVariable.Fullness >= 70) ? 90.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 65) ? 80.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 60) ? 70.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 55) ? 60.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 50) ? 50.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 45) ? 40.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 40) ? 30.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 35) ? 20.0f :
                        (OverallManager.Instance.PublicVariable.Fullness >= 30) ? 10.0f : 0.0f;
    }

    // 공격 받을 시 하트 감소
    public void DecreaseHeartsOnAttack()
    {
        OverallManager.Instance.PublicVariable.Hearts -= -1;
    }
    public void ResetHearts()
    {
        OverallManager.Instance.PublicVariable.Hearts = OverallManager.Instance.PublicVariable.MaxHearts;
    }


    // =======================================[↑게임 데이터 메소드 구역↑]==========================================
}
