using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Battlecars.Networking;

namespace Battlecars.UI
{
    public class Lobby : MonoBehaviour
    {
        private List<LobbyPlayerSlot> leftTeamSlots = new List<LobbyPlayerSlot>();
        private List<LobbyPlayerSlot> rightTeamSlots = new List<LobbyPlayerSlot>();

        [SerializeField]
        private GameObject leftTeamHolder;
        [SerializeField]
        private GameObject rightTeamHolder;

        // Flipping bool that determines which column the connected player will be added to
        private bool assigningToLeft = true;

        public void OnPlayerConnected(BattlecarsPlayerNet _player)
        {
            bool assigned = false;

            List<LobbyPlayerSlot> slots = assigningToLeft ? leftTeamSlots : rightTeamSlots;

            // Loop through each item in the list and run a lambda with the item at that index
            slots.ForEach(slot =>
            {
                // If we have assigned the value already, return from the lambda
                if (assigned)
                {
                    return;
                }
                else if (!slot.IsTaken)
                {
                    // If we haven't already assigned the player to a slot and this slot
                    // hasn't been taken, assign the player to this slot and flag 
                    // as slot been assigned
                    slot.AssignPlayer(_player);
                    assigned = true;
                }
            });

            // Flip the flag so that the next one will end up in the other list
            assigningToLeft = !assigningToLeft;
        }

        // Start is called before the first frame update
        void Start()
        {
            // Fill the two lists with their slots
            leftTeamSlots.AddRange(leftTeamHolder.GetComponentsInChildren<LobbyPlayerSlot>());
            rightTeamSlots.AddRange(rightTeamHolder.GetComponentsInChildren<LobbyPlayerSlot>());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}