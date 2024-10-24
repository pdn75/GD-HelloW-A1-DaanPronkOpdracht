using UnityEngine;
using UnityEngine.UI;
using ScriptableInput;

namespace PlatformerDemo
{
    public class CustomButtonMapping : MonoBehaviour
    {
        public ControllerConfigurationPlatformer playerCustomControls;
        public ControllerConfigurationPlatformer playerDefaultControls;

        public KeyboardInput customLeft;
        public KeyboardInput customRight;
        public KeyboardInput customButton1;
        public KeyboardInput customButton2;

        public Text playerControlsText;

        public Text messageText;

        int setPlayerControls = 0;

        private void Start()
        {
            ButtonDefaultKeys();
        }

        private void OnGUI()
        {
            if (setPlayerControls == 1)
            {
                messageText.text = "Press key for left";
                if (Event.current.isKey && Event.current.type == EventType.KeyDown && Event.current.keyCode != KeyCode.None)
                {
                    customLeft.key = Event.current.keyCode;
                    setPlayerControls++;
                }
            }
            else if (setPlayerControls == 2)
            {
                messageText.text = "Press key for right";
                if (Event.current.isKey && Event.current.type == EventType.KeyDown && Event.current.keyCode != KeyCode.None)
                {
                    customRight.key = Event.current.keyCode;
                    setPlayerControls++;
                }
            }
            else if (setPlayerControls == 3)
            {
                messageText.text = "Press key for jump";
                if (Event.current.isKey && Event.current.type == EventType.KeyDown && Event.current.keyCode != KeyCode.None)
                {
                    customButton1.key = Event.current.keyCode;
                    setPlayerControls++;
                }
            }
            else if (setPlayerControls == 4)
            {
                messageText.text = "Press key for suicide";
                if (Event.current.isKey && Event.current.type == EventType.KeyDown && Event.current.keyCode != KeyCode.None)
                {
                    customButton2.key = Event.current.keyCode;
                    setPlayerControls++;
                }
            }
            else if (setPlayerControls > 4)
            {
                playerCustomControls.left = customLeft;
                playerCustomControls.right = customRight;
                playerCustomControls.button1 = customButton1;
                playerCustomControls.button2 = customButton2;

                GameDemoManager.Instance.player.config = playerCustomControls;

                playerControlsText.text = "Player Controls" +
                    "\nMove Left: " +
                    customLeft.key +
                    "\nMove Right: " +
                    customRight.key +
                    "\nJump: " +
                    customButton1.key +
                    "\nSuicide: " +
                    customButton2.key;

                messageText.text = "";

                setPlayerControls = 0;
            }
        }

        public void ButtonRemapKeys()
        {
            setPlayerControls = 1;
        }

        public void ButtonDefaultKeys()
        {
            GameDemoManager.Instance.player.config = playerDefaultControls;

            playerControlsText.text = "Player Controls" +
                "\nMove Left: " +
                playerDefaultControls.left.name +
                "\nMove Right: " +
                playerDefaultControls.right.name +
                "\nJump: " +
                playerDefaultControls.button1.name +
                "\nSuicide: " +
                playerDefaultControls.button2.name;

            messageText.text = "";
        }
    }
}