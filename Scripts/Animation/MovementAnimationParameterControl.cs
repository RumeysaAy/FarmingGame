
using UnityEngine;

public class MovementAnimationParameterControl : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // oyun nesnesi her etkinleştirildiğinde
        // SetAnimationParameters fonksiyonu MovementEvent'e abone edilir
        EventHandler.MovementEvent += SetAnimationParameters;
    }

    private void OnDisable()
    {
        // bu oyun nesnesi artık mevcut olmadığında veya abonelikten çıkmak 
        // için devre dışı bırakıldığında oyun nesnesi aktif değildir, olay mesajını alamaz.
        // abonelikten çıkmak 
        EventHandler.MovementEvent -= SetAnimationParameters;
    }

    // SetAnimationParameters, MovementEvent'e abone fonksiyon
    private void SetAnimationParameters(float xInput, float yInput,
     bool isWalking, bool isRunning,
      bool isIdle, bool isCarrying, // boşta duruyor mu?, oyuncu bir şey taşıyor mu?
       ToolEffect toolEffect,
        bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown, // hangi yönde araç kullanıyor?
        bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown, // bir aletin kaldırılıp kaldırılmadığı
        bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown, // bir şeyler aldı mı?
        bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown, // bir aletin sallanıp sallanmadığı
        bool idleUp, bool idleDown, bool idleLeft, bool idleRight)
    {
        // animasyon için animasyon parametrelerini tetiklemek
        animator.SetFloat(Settings.xInput, xInput);
        animator.SetFloat(Settings.yInput, yInput);
        animator.SetBool(Settings.isWalking, isWalking);
        animator.SetBool(Settings.isRunning, isRunning);

        animator.SetInteger(Settings.toolEffect, (int)toolEffect);

        if (isUsingToolRight)
            animator.SetTrigger(Settings.isUsingToolRight);
        if (isUsingToolLeft)
            animator.SetTrigger(Settings.isUsingToolLeft);
        if (isUsingToolUp)
            animator.SetTrigger(Settings.isUsingToolUp);
        if (isUsingToolDown)
            animator.SetTrigger(Settings.isUsingToolDown);

        if (isLiftingToolRight)
            animator.SetTrigger(Settings.isLiftingToolRight);
        if (isLiftingToolLeft)
            animator.SetTrigger(Settings.isLiftingToolLeft);
        if (isLiftingToolUp)
            animator.SetTrigger(Settings.isLiftingToolUp);
        if (isLiftingToolDown)
            animator.SetTrigger(Settings.isLiftingToolDown);

        if (isSwingingToolRight)
            animator.SetTrigger(Settings.isSwingingToolRight);
        if (isSwingingToolLeft)
            animator.SetTrigger(Settings.isSwingingToolLeft);
        if (isSwingingToolUp)
            animator.SetTrigger(Settings.isSwingingToolUp);
        if (isSwingingToolDown)
            animator.SetTrigger(Settings.isSwingingToolDown);

        if (isPickingRight)
            animator.SetTrigger(Settings.isPickingRight);
        if (isPickingLeft)
            animator.SetTrigger(Settings.isPickingLeft);
        if (isPickingUp)
            animator.SetTrigger(Settings.isPickingUp);
        if (isPickingDown)
            animator.SetTrigger(Settings.isPickingDown);

        if (idleUp)
            animator.SetTrigger(Settings.idleUp);
        if (idleDown)
            animator.SetTrigger(Settings.idleDown);
        if (idleLeft)
            animator.SetTrigger(Settings.idleLeft);
        if (idleRight)
            animator.SetTrigger(Settings.idleRight);
    }

    private void AnimationEventPlayFootstepSound()
    {
    }
}
