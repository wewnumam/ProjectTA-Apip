namespace ProjectTA.Message
{
    public struct ActivateCharacterMessage
    {
        public string CharacterName { get; }

        public ActivateCharacterMessage(string characterName)
        {
            CharacterName = characterName;
        }
    }
}