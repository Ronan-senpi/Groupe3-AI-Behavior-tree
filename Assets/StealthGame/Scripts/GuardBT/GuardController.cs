using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    [SerializeField] private Light _spotlight;
    [SerializeField] private LayerMask _viewMask;
    float _viewDistance;
    float _viewAngle;
    Color _originalSpotLightColor;
    Transform _playerTransform;
    
    [SerializeField] private float _timeToSpotPlayer = .5f;
    float _playerVisibleTimer;
    bool _playerSpotted;

    int _targetWaypointIndex = 1;
    
    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _viewDistance = _spotlight.range * 0.9f; // La distance de détection est légèrement moins grande que la longueur du spotlight
        _viewAngle = _spotlight.spotAngle;
        _originalSpotLightColor = _spotlight.color;
        _playerSpotted = false;
        
    }

    void Update()
    {
        //_playerVisibleTimer += CanSeePlayer() ? Time.deltaTime : -Time.deltaTime;
        if(CanSeePlayer())
        {
            _playerVisibleTimer += Time.deltaTime;
        }
        else{
            _playerVisibleTimer -= Time.deltaTime;
        }

        _playerVisibleTimer = Mathf.Clamp(_playerVisibleTimer, 0, _timeToSpotPlayer);
        _spotlight.color = Color.Lerp(_originalSpotLightColor, Color.red, _playerVisibleTimer / _timeToSpotPlayer);

        _playerSpotted = _playerVisibleTimer >= _timeToSpotPlayer ?  true : false;
    }

    bool CanSeePlayer(){
        if(Vector3.Distance(transform.position, _playerTransform.position) >= _viewDistance){
            return false;
        }
        
        Vector3 dirToPlayer = (_playerTransform.position - transform.position).normalized;
        float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
        if(angleBetweenGuardAndPlayer >= _viewAngle / 2f){
            return false;
        }
        
        if(Physics.Linecast(transform.position, _playerTransform.position, _viewMask)){
            return false;
        }
        
        return true;
    }

    public bool isPlayerSpotted(){
        return _playerSpotted;
    }

    public void setTargetWaypointIndex(int targetWaypointIndex){
        _targetWaypointIndex = targetWaypointIndex;
    }

    public int getTargetWaypointIndex(){
        return _targetWaypointIndex;
    }

}
