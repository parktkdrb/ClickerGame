using System.Collections;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player _player;
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
    public ObjectPool objectPool;
    public UIManager UIManager;
    public SoundManager SoundManager;
    [SerializeField] public BigInteger Score;
    Camera camera;
    public RectTransform rt;
    private void Awake()
    {
        camera = Camera.main;
        Instance = this;
        objectPool = GetComponent<ObjectPool>();
        SoundManager = GetComponent<SoundManager>();
    }
    public void OnClick()
    {
        StartCoroutine(Effect());
    }
    public IEnumerator Effect()
    {
        // 마우스의 스크린 좌표를 사용
        UnityEngine.Vector3 mousePosition = Input.mousePosition;

        // 클릭 이벤트 처리 코드
        GameObject effect = GameManager.Instance.objectPool.EffectGet();
        effect.transform.position = camera.ScreenToWorldPoint(mousePosition); // World 좌표로 변환
        effect.transform.position = new UnityEngine.Vector3(effect.transform.position.x, effect.transform.position.y, 0);

        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.objectPool.EffectRelease(effect);
    }

}
