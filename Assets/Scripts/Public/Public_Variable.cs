using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Public_Variable : BaseMonoBehaviour
{
    // 델리게이트 및 이벤트 정의
    public delegate void TimeIncreaseEventHandler(int hoursIncreased);
    public static event TimeIncreaseEventHandler OnTimeIncreased;

    // ============================================[↓역참조 구역↓]=================================================

    private IOverallManager _overallManager;

    public IOverallManager OverallManager
    {
        get { return _overallManager; }
    }

    public void Init(IOverallManager overallManager)
    {
        _overallManager = overallManager;
    }

    // ============================================[↑역참조 구역↑]=================================================

    // ============================================[↓공용 변수 구역↓]=================================================

    // 1. 시간 수치
    private int currentHour = 0;
    public int CurrentHour
    {
        get { return currentHour; }
        set { currentHour = Mathf.Clamp(value, 0, 24); }
    }

    // 누적 시간 수치
    private int accumulatedHours = 0;
    public int AccumulatedHours
    {
        get { return accumulatedHours; }
        set
        {
            int hoursIncreased = value - accumulatedHours;
            accumulatedHours = value;

            // 누적 시간이 증가할 때 이벤트 발생
            OnTimeIncreased?.Invoke(hoursIncreased);
        }
    }

    // 2. float 스태미나 수치 0~100
    private float stamina = 100.0f;
    public float Stamina
    {
        get { return stamina; }
        set { stamina = Mathf.Clamp(value, 0f, 120f); }
    }

    // 3. float 배부름 fullness 수치 0~100
    private float fullness = 100.0f;
    public float Fullness
    {
        get { return fullness; }
        set
        {
            fullness = Mathf.Clamp(value, 0f, 100f);
        }
    }
    // 취침 시 스태미나 회복량 계산
    public void RecoverStaminaAfterSleep()
    {
        if (fullness >= 100)
            Stamina = 120.0f;
        else if (fullness >= 75)
            Stamina = 100.0f;
        else
            Stamina = (fullness >= 70) ? 90.0f :
                        (fullness >= 65) ? 80.0f :
                        (fullness >= 60) ? 70.0f :
                        (fullness >= 55) ? 60.0f :
                        (fullness >= 50) ? 50.0f :
                        (fullness >= 45) ? 40.0f :
                        (fullness >= 40) ? 30.0f :
                        (fullness >= 35) ? 20.0f :
                        (fullness >= 30) ? 10.0f : 0.0f;
    }

    // 4. 레베카의 오염도 수치 0~100
    private float contamination = 0.0f;
    public float Contamination
    {
        get { return contamination; }
        set { contamination = Mathf.Clamp(value, 0f, 100f); }
    }

    // 5. 바깥 탐사 시 체력 수치
    private float hearts = 3;
    private float maxHearts = 3; 

    public float Hearts
    {
        get { return hearts; }
        set { hearts = Mathf.Max(value, 0); }
    }

    public float MaxHearts
    {
        get { return maxHearts; }
        set { maxHearts = Mathf.Max(value, 1); }
    }

    // 게임 오버 체크
    public bool IsGameOver()
    {
        return Hearts <= 0;
    }

    // 공격 받을 시 하트 감소
    public void DecreaseHeartsOnAttack()
    {
        Hearts = Mathf.Max(hearts - 1, 0);
    }

    // 하트 초기화
    public void ResetHearts()
    {
        Hearts = maxHearts;
    }

    private void Start()
    {
        // 이벤트 핸들러 등록
        OnTimeIncreased += HandleTimeIncrease;
    }

    private void HandleTimeIncrease(int hoursIncreased)
    {
        // 배부름 감소
        Fullness -= 1.5f * hoursIncreased;
    }
    // ============================================[↑공용 변수 구역↑]=================================================
}


