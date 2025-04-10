using Agate.MVC.Base;
using ProjectTA.Message;

namespace ProjectTA.Module.CharacterDisplay
{
    public class CharacterDisplayConnector : BaseConnector
    {
        private readonly CharacterDisplayController _characterDisplay = new();

        protected override void Connect()
        {
            Subscribe<ActivateCharacterMessage>(_characterDisplay.ActivateCharacter);
            Subscribe<DeactivateCharactersMessage>(_characterDisplay.DeactivateCharacters);
        }

        protected override void Disconnect()
        {
            Unsubscribe<ActivateCharacterMessage>(_characterDisplay.ActivateCharacter);
            Unsubscribe<DeactivateCharactersMessage>(_characterDisplay.DeactivateCharacters);
        }
    }
}