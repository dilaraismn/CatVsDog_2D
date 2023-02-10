using UnityEngine;
using DG.Tweening;

public class Fishbone : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public static bool canRespawnFishbone;
    private GameManager _gameManager;
    
    private void Awake()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        canRespawnFishbone = false;
        this._rigidbody2D.isKinematic = true;
    }

    private void Update()
    {
        if (CatEnemy.catIsDead)
        {
            Destroy(this.gameObject);
        }
    }
    
    public void ThrowFishbone(float jumpPower, float posIncrease)
    {
        Vector2 currentPos = this.transform.position;
        Vector2 endPos = new Vector2(currentPos.x + posIncrease, -5); // -5 yer anlamında
        _rigidbody2D.DOJump(endPos, jumpPower, 1, 2);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            canRespawnFishbone = true;
            _gameManager.ChangePlayer();
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Dog"))
        {
            canRespawnFishbone = true;
            Destroy(this.gameObject);
        }
        if (other.CompareTag("MiddleWall"))
        {
            this._rigidbody2D.isKinematic = false;
            _rigidbody2D.DOKill();
        }
    }
}
