using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Public_Variable : BaseMonoBehaviour // 게임에서 공용으로 사용되는 변수들과 관련 이벤트가 있는 스크립트
{
    // ==========================================[↓사전 초기화 구역↓]==============================================
    // 델리게이트 및 이벤트 정의
    public delegate void TimeIncreaseEventHandler(int hoursIncreased);
    public static event TimeIncreaseEventHandler OnTimeIncreased;

    // ==========================================[↑사전 초기화 구역↑]==============================================

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

    // ============================================[↓공용 변수 구역↓]=================================================

    // 1. 시간 수치 - 현재시간
    [SerializeField]
    private int currentHour = 0;
    public int CurrentHour
    {
        get { return currentHour; }
        set { currentHour = Mathf.Clamp(value, 0, 24); }
    }

    // 1. 시간 수치 - 누적 시간
    [SerializeField]
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

    // 2. 스태미나 수치
    [SerializeField]
    private float stamina = 100.0f;
    public float Stamina
    {
        get { return stamina; }
        set { stamina = Mathf.Clamp(value, 0f, 120f); }
    }

    // 3. 배부름 수치
    [SerializeField]
    private float fullness = 100.0f;
    public float Fullness
    {
        get { return fullness; }
        set
        {
            fullness = Mathf.Clamp(value, 0f, 100f);
        }
    }

    // 4. 레베카의 오염도 수치 0~100
    [SerializeField]
    private float contamination = 0.0f;
    public float Contamination
    {
        get { return contamination; }
        set { contamination = Mathf.Clamp(value, 0f, 100f); }
    }

    // 5. 바깥 탐사 시 체력 수치
    [SerializeField]
    private float hearts = 3;
    [SerializeField]
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

    // ============================================[↑공용 변수 구역↑]=================================================
    // ==============================================[↓메서드 구역↓]==================================================
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
    // 게임 오버 체크
    public bool IsGameOver()
    {
        return Hearts <= 0;
    }
    // ==============================================[↑메서드 구역↑]==================================================
}


