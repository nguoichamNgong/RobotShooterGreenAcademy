using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        private bool inputEnabled = true;

        [Header("Pause Settings")]
        public GameObject PausePanel;
        private bool isPaused = false;

        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;
        public bool shoot;
        public bool zoom;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

        void Start()
        {
            SetCursorState(true);
        }

        void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                TogglePause();
            }
        }
        void TogglePause()
        {
            isPaused = !isPaused;
            PausePanel.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
            inputEnabled = !isPaused;
            SetCursorState(!isPaused);
        }
        public void ResumeGame()
        {
            isPaused = false;
            PausePanel.SetActive(false);
            Time.timeScale = 1;
            inputEnabled = true;
            SetCursorState(true);
        }
        public void ReturnToMenu()
        {
            Time.timeScale = 1; 
            SceneManager.LoadScene("Ui Manager"); 
        }

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
        {
            if (!inputEnabled) return;
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (!inputEnabled || !cursorInputForLook) return;
            LookInput(value.Get<Vector2>());
        }

        public void OnJump(InputValue value)
        {
            if (!inputEnabled) return;
            JumpInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            if (!inputEnabled) return;
            SprintInput(value.isPressed);
        }

        public void OnShoot(InputValue value)
        {
            if (!inputEnabled) return;
            ShootInput(value.isPressed);
        }

        public void OnZoom(InputValue value)
        {
            if (!inputEnabled) return;
            ZoomInput(value.isPressed);
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        public void ShootInput(bool newShootState)
        {
            shoot = newShootState;
        }

        public void ZoomInput(bool newZoomState)
        {
            zoom = newZoomState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        public void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

}