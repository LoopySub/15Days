using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
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
                if (am_I_outside == true)
                {
                    OverallManager.Instance.GameDataManager.Ending(Ending_type.OverNight);
                    return;
                }
                Sleep_and_wake_up();
                if (value == 24)
                {
                    AccumulatedHours += (value - currentHour + 8);
                    currentHour = 8;
                }
                else
                {
                    AccumulatedHours += ((value - 24) + 8);
                    currentHour = 8;
                }
            }
            else
            {
                AccumulatedHours += (value - currentHour);
                currentHour = value;

            }
            if (Am_I_outside == true)
            {
                if (currentHour >= 19 && currentHour < 23)
                {
                    OverallManager.Instance.UiManager.NightLightOn();
                }
                else if (currentHour >= 23)
                {
                    OverallManager.Instance.UiManager.DeepNightLightOn();
                }
                else
                {
                    OverallManager.Instance.UiManager.MorningLightOn();
                }
            }

            OverallManager.Instance.UiManager.textRenewal();
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
    private int day;
    public int Day
    {
        get { return day; }
        set
        {
            day = value;
            OverallManager.Instance.UiManager.textRenewal();
        }
    }

    // 2. 스태미나 수치
    [SerializeField]
    private float stamina = 100.0f;
    public float Stamina
    {
        get { return stamina; }
        set
        {
            stamina = Mathf.Clamp(value, -10f, 120f);
            OverallManager.Instance.UiManager.textRenewal();
        }
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
        set { rebeccaStatus = value; }
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
    [SerializeField]
    private bool am_I_outside = false;
    public bool Am_I_outside
    {
        get { return am_I_outside; }
        set
        {
            am_I_outside = value;
            if (am_I_outside == false)
            {
                OverallManager.Instance.UiManager.ShowStaminaBar();
                OverallManager.Instance.UiManager.MorningLightOn();
                OverallManager.Instance.UiManager.ShowRebeccaUI(true);
            }
            else
            {
                OverallManager.Instance.UiManager.ShowHpBar();
                OverallManager.Instance.UiManager.ShowRebeccaUI(false);
            }
        }
    }

    //플레이어 맵 이동 시 좌표 정보
    [SerializeField]
    private Vector3 nextCoordinate;
    public Vector3 NextCoordinate
    {
        get { return nextCoordinate; }
        set { nextCoordinate = value; }
    }

    //게임 상태값
    [SerializeField]
    private GameState gameState;
    public GameState GameState
    {
        get { return gameState; }
        set
        {                         //게임 상태 값에 따라 플레이어 캐릭터가 보이고 안보이고 및 게임 시간 정지 / 재생
            gameState = value;
            OverallManager.Instance.PlayerManager.playerSetActive(gameState);
            GameStateHandler();
        }
    }

    //UI 떠있는지 체크
    [SerializeField]
    private bool isUIPopup;
    public bool IsUIPopup
    {
        get { return isUIPopup; }
        set { isUIPopup = value; }
    }

    //대화창 떠있는지 체크
    [SerializeField]
    private bool isDialog;
    public bool IsDialog
    {
        get { return isDialog; }
        set { isDialog = value; }
    }

    //선택박스가 떠있는지
    [SerializeField]
    private bool isChoiceBoxUI;
    public bool IsChoiceBoxUI
    {
        get { return isChoiceBoxUI; }
        set { isChoiceBoxUI = value; }
    }

    //선택지에서 선택값이 무엇인지
    [SerializeField]
    private bool isChoice;
    public bool IsChoice
    {
        get { return isChoice; }
        set {
            isChoice = value;
            OverallManager.Instance.UiManager.HandleIsTargetedChanged();
        }
    }

    //휴식했는지
    [SerializeField]
    private bool isRest;
    public bool IsRest
    {
        get { return isRest; }
        set { isRest = value; }
    }

    //엔딩 타입
    [SerializeField]
    private Ending_type ending_Type = Ending_type.None;
    public Ending_type Ending_Type
    {
        get { return ending_Type; }
        set { ending_Type = value; }
    }

    //레베카 방 진입 중인지 여부
    [SerializeField]
    private bool isRebeccaRoomEnter;
    public bool IsRebeccaRoomEnter
    {
        get { return isRebeccaRoomEnter; }
        set { isRebeccaRoomEnter = value; }
    }

    //그날 아침 독백 했는지 여부
    [SerializeField]
    private bool isDM;
    public bool IsDM
    {
        get { return isDM; }
        set { isDM = value; }
    }

    //그날 라디오 썼는지 여부
    [SerializeField]
    private bool isDayRadio;
    public bool IsDayRadio
    {
        get { return isDayRadio; }
        set { isDayRadio = value; }
    }


    //그날 PC 썼는지 여부
    [SerializeField]
    private bool isDayPC;
    public bool IsDayPC
    {
        get { return isDayPC; }
        set { isDayPC = value; }
    }

    //PC 고장났는지 여부
    [SerializeField]
    private bool isPCBrocken;
    public bool IsPCBrocken
    {
        get { return isPCBrocken; }
        set { isPCBrocken = value; }
    }

    //연구소 입구 키 가졌는지 여부
    [SerializeField]
    private bool isLabMainKeyGet;
    public bool IsLabMainKeyGet
    {
        get{return isLabMainKeyGet;}
        set { isLabMainKeyGet = value;}
    }

    //백신 가졌는지 여부
    [SerializeField]
    private bool isVaccineGet;
    public bool IsVaccineGet
    {
        get { return isVaccineGet; }
        set { isVaccineGet = value; }
    }

    //레베카 치유됐는지 여부
    [SerializeField]
    private bool isRebeccaCured;
    public bool IsRebeccaCured
    {
        get { return isRebeccaCured; }
        set { isRebeccaCured = value; }
    }

    //항생제 갖고 있는지 여부
    [SerializeField]
    private bool isGetAntibiotic;
    public bool IsGetAntibiotic
    {
        get { return isGetAntibiotic; }
        set { isGetAntibiotic = value; }
    }

    [SerializeField]
    private bool isDeto_A;
    public bool IsDetoA
    {
        get { return isDeto_A;}
        set { isDeto_A = value;}
    }

    [SerializeField]
    private bool isDeto_B;
    public bool IsDetoB
    {
        get { return isDeto_B; }
        set { isDeto_B = value;}
    }

    [SerializeField]
    private bool isDeto_C;
    public bool IsDetoC
    {
        get { return isDeto_C; }
        set { isDeto_C = value;}
    }

    [SerializeField]
    private bool isLabkey_B;
    public bool IsLabkey_B
    {
        get { return isLabkey_B; }
        set { isLabkey_B = value;}
    }

    [SerializeField]
    private bool isBattery;
    public bool IsBattery
    {
        get { return isBattery; }
        set { isBattery = value; }
    }

    [SerializeField]
    private int pastDay;
    public int PastDay
    {
        get { return pastDay; }
        set { pastDay = value; } 
    }


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
        if (RebeccaStatus == RebeccaStatus.Cured)
        {
            OverallManager.Instance.UiManager.ShowRebeccaUI(true);
        }
        else
        {
            OverallManager.Instance.UiManager.ContainHide();
        }
            OverallManager.Instance.UiManager.ShowRebeccaUI(true);
            Day = (AccumulatedHours / 24) + 2;
            OverallManager.Instance.UiManager.DayChangeTextOn(true);
            IsDayRadio = false;
            IsDayPC = false;
            IsDM = false;
        if (Day == 7)
        {
            IsPCBrocken = true;
        }
        if(Day >= 15)
        {
            if (IsRebeccaCured)
            {
                OverallManager.Instance.GameDataManager.Ending(Ending_type.True);
            }
            else
            {
                OverallManager.Instance.GameDataManager.Ending(Ending_type.Normal);
            }
        }
        if (Ending_Type == Ending_type.None)
        {
            OverallManager.Instance.PublicVariable.NextCoordinate = new Vector3(5.48f, -1.36f, 0); //플레이어의 다음 맵 위치 전달
            Time.timeScale = 0.5f;

            OverallManager.Instance.SceneTransition.TransitToNextScene("Game_Livingroom Scene");
        }
    }
    // Contamination 값에 따라 Rebecca 상태 업데이트
    private void UpdateRebeccaStatus()
    {
        if (RebeccaStatus != RebeccaStatus.Cured)
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
    }

    private void GameStateHandler()
    {
        if(GameState == GameState.Cutscene)
        {
            OverallManager.Instance.UiManager.HideStateUI();
        }

        if (GameState == GameState.Playing)
        {
            // Playing 상태일 경우
            Time.timeScale = 1f; // 정상 속도로 작동
        }
        else if (GameState == GameState.Interface_On)
        {
            Time.timeScale = 0f; // 시간을 정지
        }
    }
    // ==============================================[↑메서드 구역↑]==================================================
}


