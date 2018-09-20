using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GonzoMovement : MonoBehaviour
{
    private AudioFSM AudioManager;

    public enum MoveDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public MoveDirection moveDirection;
    public Vector3 dir = Vector3.zero;
    public float moveSpeed = 5;
    public bool hasHitGoal = false;
    public bool hasHitWall = false;
    public bool isReady = false;
    public bool isRotating = false;

    private ButtonManager bMan;
    private RhoombaAnimationManager rMan;
    private MoveDirection startDir;
    private Vector3 startPos;

    public void OnInit()
    {
        bMan = FindObjectOfType<ButtonManager>();
        rMan = GetComponentInChildren<RhoombaAnimationManager>();
        rMan.Init();
        hasHitGoal = false;
        hasHitWall = false;
        isReady = false;
        isRotating = false;
        startDir = moveDirection;
        startPos = transform.position;
        ChangeDirection(moveDirection);
    }

    private void Update()
    {
        if (hasHitGoal || isRotating)
            return;

        if (!hasHitWall && isReady)
            transform.Translate(dir * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.P))
        {
            AudioFSM.AudioFsm.PlaySound(AudioFSM.AudioFsm.AreYouSureAudioClip);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Point")
        {
            TileBehaviour tb = other.GetComponentInChildren<TileBehaviour>();
            if (tb != null)
                StartCoroutine(StartChangeDirection(tb.GetDirection(), tb.gameObject));
            //Debug.Log( "We are hitting tiles" );
        }

        if (other.tag == "Goal")
        {
            StartCoroutine(StartWinGame());
        }

        if (other.tag == "Wall")
        {
            AudioFSM.AudioFsm.PlaySound(AudioFSM.AudioFsm.BonkAudioClip);
            hasHitWall = true;
            rMan.PlayHitWall();
        }
    }

    private IEnumerator StartChangeDirection(MoveDirection _dir, GameObject obj)
    {
        yield return new WaitForSeconds((1 / moveSpeed) * 3);
        isRotating = true;
        transform.position = obj.transform.position;
        yield return new WaitForSeconds(0.1f);
        isRotating = false;
        AudioManager.PlaySound(AudioManager.RhoombaAudioClip);
        ChangeDirection(_dir);
    }

    private IEnumerator StartWinGame()
    {
        yield return new WaitForSeconds((1 / moveSpeed) * 3);
        hasHitGoal = true;
        rMan.gameObject.SetActive(false);
        bMan.OnEnterGoal();
    }

    private void ChangeDirection(MoveDirection _dir)
    {
        switch (_dir)
        {
            case MoveDirection.UP:
                dir = Vector3.up;
                if (!isReady)
                    rMan.PlayUpSleep();
                else
                    rMan.PlayUpMoving();
                break;

            case MoveDirection.LEFT:
                dir = Vector3.left;
                if (!isReady)
                    rMan.PlaySideSleep(false);
                else
                    rMan.PlaySideMoving(false);
                break;

            case MoveDirection.RIGHT:
                dir = Vector3.right;
                if (!isReady)
                    rMan.PlaySideSleep(true);
                else
                    rMan.PlaySideMoving(true);
                break;

            case MoveDirection.DOWN:
                dir = Vector3.down;
                if (!isReady)
                    rMan.PlayDownSleep();
                else
                    rMan.PlayDownMoving();
                break;
        }
    }

    private void WakeUpRhoomba(MoveDirection _dir)
    {
        switch (_dir)
        {
            case MoveDirection.UP:
                rMan.PlayUpWakeUp();
                break;

            case MoveDirection.LEFT:
                rMan.PlaySideWakeUp(false);
                break;

            case MoveDirection.RIGHT:
                rMan.PlaySideWakeUp(true);
                break;

            case MoveDirection.DOWN:
                rMan.PlayDownWakeUp();
                break;
        }
    }

    private IEnumerator startWakeUpRhoomba()
    {
        WakeUpRhoomba(startDir);
        yield return new WaitForSeconds(1.07f);
        isReady = true;
        ChangeDirection(startDir);
    }

    public void OnStart()
    {
        StartCoroutine(startWakeUpRhoomba());
        AudioFSM.AudioFsm.PlaySound(AudioFSM.AudioFsm.RhoombaAudioClip);
    }

    public void Reset()
    {
        StopAllCoroutines();
        hasHitGoal = false;
        hasHitWall = false;
        isReady = false;
        transform.position = startPos;
        rMan.gameObject.SetActive(true);
        ChangeDirection(startDir);
    }
}