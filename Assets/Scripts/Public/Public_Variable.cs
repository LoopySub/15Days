using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Public_Enum;

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
    //여기에 게임 전체에 공용으로 사용되는 변수들을 정의합니다.

    // 1. 시간 수치 - 현재시간
    [SerializeField]
    private int currentHour = 0;
    public int CurrentHour
    {
        get { return currentHour; }
        set { 
                if ((value) >= 24)
                {
                    Sleep_and_wake_up();
                    AccumulatedHours += (32 - value);
                    currentHour = 8;
                }
                else
                {
                    AccumulatedHours += (value - currentHour);
                    currentHour = value;
                }
            }
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

    // 1. 시간 수치 - 날(day)
    [SerializeField]
    private int day = 0;
    public int Day
    {
        get { return day; }
        set
        {
            day = value;
        }
    }

    // 2. 스태미나 수치
    [SerializeField]
    private float stamina = 100.0f;
    public float Stamina
    {
        get { return stamina; }
        set { stamina = Mathf.Clamp(value, -10f, 120f); }
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
            if (fullness <= 0f)
            {
                OverallManager.Instance.GameDataManager.Ending(Ending_type.Starvation);
            }
        }
    }

    // 4. 레베카의 오염도 수치 0~100
    [SerializeField]
    private float contamination = 0.0f;
    public float Contamination
    {
        get { return contamination; }
        set 
        { 
            contamination = Mathf.Clamp(value, 0f, 100f);
            // 상태 업데이트
            UpdateRebeccaStatus();
        }
    }

    // 4. 레베카의 오염도에 따른 상태값
    private RebeccaStatus rebeccaStatus = RebeccaStatus.Cold;
    public RebeccaStatus RebeccaStatus
    {
        get { return rebeccaStatus; }
    }

    // 5. 바깥 탐사 시 체력 수치
    [SerializeField]
    private float hearts = 3;
    [SerializeField]
    private float maxHearts = 3; 

    public float Hearts
    {
        get { return hearts; }
        set 
        { 
            hearts = Mathf.Max(value, 0);
            if (hearts == 0)
            {
                OverallManager.Instance.GameDataManager.Ending(Ending_type.GameOver);
            }
        }
    }

    // 5. 최대 체력
    public float MaxHearts
    {
        get { return maxHearts; }
        set { maxHearts = Mathf.Max(value, 1); }
    }

    // 현재 상태가 바깥인지 안인지
    private bool am_I_outside =false;
    public bool Am_I_outside
    {
        get { return am_I_outside; }
        set { am_I_outside = value; }
    }

    //플레이어 맵 이동 시 좌표 정보
    public Vector3 NextCoordinate;

    // ============================================[↑공용 변수 구역↑]=================================================
    // ==============================================[↓메서드 구역↓]==================================================
    //여기에는 수치 변화에 따른 트리거 및 트리거 관련 메서드만 작성합니다.


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
    private void Sleep_and_wake_up() //취침 시 하트, 스태미나, 오염도 변화. 날짜 변경
    {
        OverallManager.Instance.GameDataManager.ResetHearts();
        OverallManager.Instance.GameDataManager.RecoverStaminaAfterSleep();
        OverallManager.Instance.GameDataManager.Contamination_Increases();
        Day = (AccumulatedHours / 24) +1;
    }
    // Contamination 값에 따라 Rebecca 상태 업데이트
    private void UpdateRebeccaStatus()
    {
        if (contamination < 50)
            rebeccaStatus = RebeccaStatus.Cold;
        else if (contamination < 70)
            rebeccaStatus = RebeccaStatus.Unstable;
        else if (contamination < 80)
            rebeccaStatus = RebeccaStatus.Violent;
        else if (contamination < 90)
            rebeccaStatus = RebeccaStatus.ZombieLike;
        else if (contamination < 100)
            rebeccaStatus = RebeccaStatus.AlmostZombie;
        else
            rebeccaStatus = RebeccaStatus.Zombie;
    }
    // ==============================================[↑메서드 구역↑]==================================================
}


