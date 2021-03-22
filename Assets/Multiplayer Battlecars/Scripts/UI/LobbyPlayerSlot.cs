using UnityEngine;
using UnityEngine.UI;

using TMPro;

using Battlecars.Networking;

namespace Battlecars.UI
{
    public class LobbyPlayerSlot : MonoBehaviour
    {
        public bool IsTaken => player != null;

        [SerializeField]
        private TextMeshProUGUI nameDisplay;
        [SerializeField]
        private Button playerButton;

        private BattlecarsPlayerNet player = null;

        // Set the player in this slot to the passed player
        public void AssignPlayer(BattlecarsPlayerNet _player) => player = _player;

        // Update is called once per frame
        void Update()
        {
            // If the slot is empty then set the button shouldn't be active
            playerButton.interactable = IsTaken;
            // If the player is set, then display their name, otherwise display "Awaiting player..."
            nameDisplay.text = IsTaken ? player.username : "Awaiting Player...";
        }
    }
}