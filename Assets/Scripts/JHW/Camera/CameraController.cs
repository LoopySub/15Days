using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : BaseMonoBehaviour
{
    private static CameraController _instance;

    private void Awake()
    {
        // 이미 인스턴스가 있는지 확인하고, 있다면 자신을 파괴
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        // 이 오브젝트를 파괴되지 않도록 설정
        DontDestroyOnLoad(gameObject);
    }



    public float cameraSpeed = 5.0f;

    public GameObject player;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        this.transform.Translate(moveVector);
    }

    private void OnEnable()
    {
        // 씬 로드 후에 호출되는 이벤트에 대한 리스너 추가
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // 리스너 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬이 로드된 후에 호출되는 콜백
        // 이동할 좌표를 OverallManager.Instance.returnMoveMapInfo()로 설정
        Vector3 position = OverallManager.Instance.PublicVariable.NextCoordinate;
        position.z = -1;
        transform.position = position;
    }
}
