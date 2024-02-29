using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOverallManager
{

}
public class OverallManager : BaseMonoBehaviour, IOverallManager //전체 총괄 통합 매니저 스크립트
{
    // ============================================[↓싱글톤 구역↓]=================================================

    // 싱글톤 인스턴스
    private static OverallManager _instance;

    // 외부에서 싱글톤 인스턴스에 접근할 수 있는 프로퍼티
    public static OverallManager Instance
    {
        get
        {
            // 인스턴스가 없으면 생성
            if (_instance == null)
            {
                // FindObjectOfType는 런타임 중에 해당 타입의 객체를 찾음
                _instance = FindObjectOfType<OverallManager>();

                // 찾지 못한 경우 씬에 없다면 새로 생성
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(OverallManager).Name);
                    _instance = singletonObject.AddComponent<OverallManager>();
                }
            }

            return _instance;
        }
    }

    // Awake 메서드에서 초기화
    private void Awake()
    {
        // 이미 다른 인스턴스가 있다면 현재 인스턴스를 파괴
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }

        // 싱글톤 인스턴스로 현재 인스턴스를 설정
        _instance = this;

        // 씬 전환 시 파괴되지 않도록 설정
        DontDestroyOnLoad(this.gameObject);
    }

    // ============================================[↑싱글톤 구역↑]=================================================

    // ============================================[↓직렬화 구역↓]=================================================

    [SerializeField]
    private Public_Enum _PublicEnum;

    [SerializeField]
    private Public_Structer _PublicStructer;

    [SerializeField]
    private Public_Utility _PublicUtility;

    [SerializeField]
    private Public_Variable _PublicVariable;

    [SerializeField]
    private TestManager _TestManager;

    [SerializeField]
    private SoundManager _SoundManager;

    [SerializeField]
    private UiManager _UiManager;

    [SerializeField]
    private GameDataManager _GameDataManager;

    [SerializeField]
    private PlayerManager _PlayerManager;

    [SerializeField]
    private SceneTransition _SceneTransition;

    // ============================================[↑직렬화 구역↑]=================================================
    // ==========================================[↓데이터 참조 구역↓]==============================================
    public Public_Variable PublicVariable
    {
        get { return _PublicVariable; }
    }
    public GameDataManager GameDataManager
    {
        get { return _GameDataManager; }
    }
    public Public_Enum PublicEnum 
    { 
        get { return _PublicEnum; } 
    }
    public Public_Utility PublicUtility
    {
        get { return _PublicUtility; }
    }
    public UiManager UiManager
    {
        get { return _UiManager; } 
    }

    public PlayerManager PlayerManager
    {
        get { return _PlayerManager; }
    }
    public SceneTransition SceneTransition
    {
        get { return _SceneTransition; }
    }


    // ==========================================[↑데이터 참조 구역↑]==============================================
}

