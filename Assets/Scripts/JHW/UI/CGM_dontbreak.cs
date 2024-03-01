using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGM_dontbreak : MonoBehaviour
{
     private static CGM_dontbreak _instance;

private void Awake()
{
    // �̹� �ν��Ͻ��� �ִ��� Ȯ���ϰ�, �ִٸ� �ڽ��� �ı�
    if (_instance != null && _instance != this)
    {
        Destroy(gameObject);
        return;
    }

    _instance = this;

    // �� ������Ʈ�� �ı����� �ʵ��� ����
    DontDestroyOnLoad(gameObject);
} 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
