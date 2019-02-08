using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Examine")]
public class Examine : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        if (separatedInputWords.Length>1)
        {
            string verb = separatedInputWords[0];
            string noun = separatedInputWords[1];
            string response = controller.TestVerbDictionaryWithNoun(controller.interactableItems.examineDictionary, verb, noun);
            controller.LogStringWithReturn(response);
        }
    }
}
