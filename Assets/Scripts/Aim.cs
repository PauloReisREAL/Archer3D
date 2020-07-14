using UnityEngine;

namespace MainLeafShooter.Player.MainCamera {
    /// <summary>
    /// Movement of the first person camera.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("Main Leaf Shooter/Player/Aim")]
    public class Aim : MonoBehaviour {
        /// <summary>Speed of the FPS camera when moving.</summary>
        [SerializeField]
        private float mouseSensitivity;

        [SerializeField]
        private Transform playerBody;

        float xAxisClamp = 0f;

        /// <summary>
        /// Handles the camera movement based on Mouse Input.
        /// </summary>
        public void move () {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            float rotAmountX = mouseX * mouseSensitivity;
            float rotAmountY = mouseY * mouseSensitivity;

            xAxisClamp -= rotAmountY;

            Vector3 targetRotCam = transform.rotation.eulerAngles;
            Vector3 targetRotBody = playerBody.rotation.eulerAngles;

            targetRotCam.x -= rotAmountY;
            targetRotBody.y += rotAmountX;

            if (xAxisClamp > 90) {
                xAxisClamp =  90;
                targetRotCam.x = 90;
            } else if (xAxisClamp < -90) {
                xAxisClamp = -90;
                targetRotCam.x = 270;
            }

            transform.rotation = Quaternion.Euler(targetRotCam);
            playerBody.rotation = Quaternion.Euler(targetRotBody);
        }

        private void Update()
        {
            move();
        }
    } 
}