using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class CharacterController : NetworkBehaviour
{    
    [SerializeField] private CharacterStats stats;


    private Rigidbody2D rb;
    private Animator anim;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


        OnPrimaryFirePress = new UnityEvent();
        OnPrimaryFireRelease = new UnityEvent();
        OnSecondaryFirePress = new UnityEvent();
        OnSecondaryFireRelease = new UnityEvent();

        OnAbility1Press = new UnityEvent();
        OnAbility1Release = new UnityEvent();
        OnAbility2Press = new UnityEvent();
        OnAbility2Release = new UnityEvent();
        OnAbility3Press = new UnityEvent();
        OnAbility3Release = new UnityEvent();
    }



    private Vector2 moveDir;

    //WASD movement
    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (IsOwner == false)
        {
            return;
        }

        moveDir = ctx.ReadValue<Vector2>();
    }


    #region Input Detection And Events For Primary And Secondary Fire

    [HideInInspector]
    public UnityEvent OnPrimaryFirePress;
    [HideInInspector]
    public UnityEvent OnPrimaryFireRelease;

    public void OnPrimaryFire(InputAction.CallbackContext ctx)
    {
        if (IsOwner == false)
        {
            return;
        }

        if (ctx.performed)
        {
            OnPrimaryFirePress.Invoke();
        }
        else if (ctx.canceled)
        {
            OnPrimaryFireRelease.Invoke();
        }
    }


    [HideInInspector]
    public UnityEvent OnSecondaryFirePress;
    [HideInInspector]
    public UnityEvent OnSecondaryFireRelease;

    public void OnSecondaryFire(InputAction.CallbackContext ctx)
    {
        if (IsOwner == false)
        {
            return;
        }

        if (ctx.performed)
        {
            OnSecondaryFirePress.Invoke();
        }
        else if (ctx.canceled)
        {
            OnSecondaryFireRelease.Invoke();
        }
    }

    #endregion



    #region Input Detection And Events For Ability 1,2 and 3

    [HideInInspector]
    public UnityEvent OnAbility1Press;
    [HideInInspector]
    public UnityEvent OnAbility1Release;

    public void OnAbility1(InputAction.CallbackContext ctx)
    {
        if (IsOwner == false)
        {
            return;
        }

        if (ctx.performed)
        {
            OnAbility1Press.Invoke();
        }
        else if (ctx.canceled)
        {
            OnAbility1Release.Invoke();
        }
    }


    [HideInInspector]
    public UnityEvent OnAbility2Press;
    [HideInInspector]
    public UnityEvent OnAbility2Release;

    public void OnAbility2(InputAction.CallbackContext ctx)
    {
        if (IsOwner == false)
        {
            return;
        }

        if (ctx.performed)
        {
            OnAbility2Press.Invoke();
        }
        else if (ctx.canceled)
        {
            OnAbility2Release.Invoke();
        }
    }


    [HideInInspector]
    public UnityEvent OnAbility3Press;
    [HideInInspector]
    public UnityEvent OnAbility3Release;

    public void OnAbility3(InputAction.CallbackContext ctx)
    {
        if (IsOwner == false)
        {
            return;
        }

        if (ctx.performed)
        {
            OnAbility3Press.Invoke();
        }
        else if (ctx.canceled)
        {
            OnAbility3Release.Invoke();
        }
    }

    #endregion



    private void Update()
    {
        if (IsOwner == false)
        {
            return;
        }

        //flip character sprite to correct direction with animator
        anim.SetFloat("Horizontal", Mathf.Round(moveDir.x));
        anim.SetFloat("Vertical", Mathf.Round(moveDir.y));

        Vector2 vel = moveDir * stats.MoveSpeed;

        rb.velocity = vel;

        UpdatePlayer_ServerRPC(moveDir, stats.MoveSpeed);
    }


    [ServerRpc(RequireOwnership = false)]
    private void UpdatePlayer_ServerRPC(Vector2 moveDir, float speed)
    {
        UpdatePlayer_ClientRPC(moveDir, speed);
    }


    [ClientRpc(RequireOwnership = false)]
    private void UpdatePlayer_ClientRPC(Vector2 moveDir, float speed)
    {
        //flip character sprite to correct direction with animator
        anim.SetFloat("Horizontal", Mathf.Round(moveDir.x));
        anim.SetFloat("Vertical", Mathf.Round(moveDir.y));

        rb.velocity = moveDir * speed;
    }
}
