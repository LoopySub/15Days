using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Public_Variable : BaseMonoBehaviour
{
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


    // 게임 설정과 관련된 변수
    public int initialPlayerHealth = 100;
    public float playerMoveSpeed = 5.0f;
    public Color playerDefaultColor = Color.white;

    // 리소스 관리를 위한 변수
    public GameObject[] enemyPrefabs;
    public AudioClip[] soundEffects;

    // 게임 상태와 관련된 변수
    public bool isGamePaused = false;
    public int currentScore = 0;

    // 플레이어 정보와 상태를 저장하는 변수
    public string playerName = "Player1";
    public Vector3 playerStartPosition = new Vector3(0, 0, 0);
    public bool isPlayerAlive = true;

    // 아이템과 인벤토리 관련 변수
    public int playerGold = 0;
    public List<GameObject> playerInventory = new List<GameObject>();
    public int maxInventorySize = 20;


    // 화면 및 UI 설정 변수
    public bool showHUD = true;
    public Color uiThemeColor = Color.blue;
    public int screenResolutionWidth = 1920;
    public int screenResolutionHeight = 1080;

    // 레벨 및 경험치 변수
    public int playerLevel = 1;
    public int experiencePoints = 0;
    public int experienceToNextLevel = 100;

    // 다양한 게임 모드와 관련된 변수
    public bool isTutorialMode = false;
    public bool isMultiplayer = false;
    public int numberOfPlayers = 1;

    // 시간과 이벤트 관련 변수
    public float gameTimeElapsed = 0.0f;
    public bool isNightTime = false;

    // 기타 게임 설정 변수
    public bool useSound = true;
    public int difficultyLevel = 2;
    public bool enableDebugMode = false;

    // ============================================[↑공용 변수 구역↑]=================================================
}
