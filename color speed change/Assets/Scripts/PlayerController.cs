using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private int _speed, _Coin;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _color, _color1, _color2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }


    void Update()
    {
        Hareket();
    }

    private void Hareket()
    {
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        transform.Translate(hor * Time.deltaTime * _speed, 0, ver * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {


            _Coin++;
            Destroy(other.gameObject);
            _meshRenderer.material.color = _color;
        }

        if (other.tag == "Coin1")
        {


            _Coin++;
            Destroy(other.gameObject);
            _meshRenderer.material.color = _color1;
        }



    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "color")
        {
            _Coin -= 1;
            _meshRenderer.material.color = _color2;
            if (_Coin < 0)
            {
                Destroy(gameObject);
                
            }
            Destroy(other.gameObject);

        }

        if (other.tag == "speed")
        {
            Destroy(other.gameObject);
            StartCoroutine(speedMove());
        }
    }

    IEnumerator speedMove()
    {
        _speed += 2;
        yield return new WaitForSeconds(3f);
        _speed -= 2;
    }

}
