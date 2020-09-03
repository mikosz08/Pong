using UnityEngine;

public class HealthManager : MonoBehaviour{
    [SerializeField] private GameObject[] hearts;
    private SpriteRenderer[] _spriteRenderers;
    public int LastHeartIndex { get; set; }

    [SerializeField] private GameObject ball;

    public HealthManager( int lastHeartIndex ){
        LastHeartIndex = lastHeartIndex;
    }

    private void Start(){
        _spriteRenderers = new SpriteRenderer[3];
        LastHeartIndex = _spriteRenderers.Length - 1;
        GetHeartSpriteRenderers();
    }

    private void GetHeartSpriteRenderers(){
        var i = 0;
        foreach (var heart in hearts) {
            _spriteRenderers[i] = heart.GetComponent<SpriteRenderer>();
            ++i;
        }
    }

    public void RemoveHeart(){
        if (LastHeartIndex < 0) return;
        _spriteRenderers[LastHeartIndex].enabled = false;
        --LastHeartIndex;
    }

}