using System.Threading.Tasks;
using Events;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class DiceRoll : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float _forceX, _forceY, _forceZ;
    
    private Vector3 _startingPosition;

    [SerializeField] private float maxRandomForceValue, startRollingForce;
    [SerializeField] private Transform[] diceFaces;

    public int diceFaceNum;
    private bool _delayFinished;
    private bool _hasStoppedRolling;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        if (!_delayFinished) return;

        if (!_hasStoppedRolling && _rigidbody.linearVelocity.sqrMagnitude == 0f)
        {
            _hasStoppedRolling = true;
            GetNumberOnTopFace();
        }
    }

    private void GetNumberOnTopFace()
    {
        var topFace = 0;
        var lastYPosition = diceFaces[0].position.y;

        for (var i = 0; i < diceFaces.Length; i++)
        {
            if (!(diceFaces[i].position.y > lastYPosition)) continue;
            
            lastYPosition = diceFaces[i].position.y;
            topFace = i;
        }
        
        EventBus.Invoke(new ScoreChangedEvent(topFace + 1));
    }

    public void RollDice()
    {
        _delayFinished = false;
        _hasStoppedRolling = false;
        transform.position = _startingPosition;
        transform.rotation = Quaternion.identity;

        _forceX = Random.Range(0, maxRandomForceValue);
        _forceY = Random.Range(0, maxRandomForceValue);
        _forceZ = Random.Range(0, maxRandomForceValue);
        
        _rigidbody.AddForce(Vector3.up * startRollingForce);
        _rigidbody.AddTorque(_forceX, _forceY, _forceZ);

        DelayResult();
    }

    private void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startingPosition = transform.position;
    }
    
    private async void DelayResult()
    {
        await Task.Delay(1000);
        _delayFinished = true;
    }
}
