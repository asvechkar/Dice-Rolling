using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class DiceRoll : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float _forceX, _forceY, _forceZ;

    [SerializeField] private float maxRandomForceValue, startRollingForce;

    public int diceFaceNum;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RollDice();
        }
    }

    private void RollDice()
    {
        _rigidbody.isKinematic = false;

        _forceX = Random.Range(0, maxRandomForceValue);
        _forceY = Random.Range(0, maxRandomForceValue);
        _forceZ = Random.Range(0, maxRandomForceValue);
        
        _rigidbody.AddForce(Vector3.up * startRollingForce);
        _rigidbody.AddTorque(_forceX, _forceY, _forceZ);
    }

    private void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        //transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 0);
    }
}
