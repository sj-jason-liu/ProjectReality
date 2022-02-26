using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityStone : MonoBehaviour
{
    [SerializeField]
    private float _timeToVirtual = 7f;

    private SpriteRenderer _renderer;
    private CircleCollider2D _collider;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        if(_renderer == null)
        {
            Debug.LogError("SpriteRenderer is NULL!");
        }
        _collider = GetComponent<CircleCollider2D>();
        if(_collider == null)
        {
            Debug.LogError("CircleCollider is NULL!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.Instance.ShowReality();
            UIManager.Instance.StoneActivation(true);
            _renderer.enabled = false;
            _collider.enabled = false;
            UIManager.Instance.StartCountdown(_timeToVirtual);
            StartCoroutine(BackToVirtual());
        }
    }

    IEnumerator BackToVirtual()
    {
        yield return new WaitForSeconds(_timeToVirtual);
        UIManager.Instance.StoneActivation(false);
        GameManager.Instance.DisableReality();
        Destroy(gameObject); //destroy stone
    }
}
