﻿using System;
using System.Collections.Generic;

namespace API
{
    class Test
    {
        static void Main(string[] args)
        {
            ScenarioList scenarioList = new ScenarioList();

            Scenario scenarioOne = new Scenario(new List<Choice>(), "videoPath", "ambientSoundPath", "narrationPath", "soundEffectPath", "scenarioText", "scenarioChoiceText", 0.0f, 0.0f, 0.0f, 0.0f, true, false, false);
            Scenario scenarioTwo = new Scenario(new List<Choice>(), "Scenarios", "Scenarios", "Scenarios", "Scenarios", "Scenarios", "Scenarios", 1.1f, 2.22f, 3.333f, 4.4444f, false, true, false);
            Scenario scenarioThree = new Scenario(new List<Choice>(), "Alex", "Alexander", "Alexander Whitehead", "Alexander Charles Whitehead", "Alexander Charles Whitehead", "Alexander Charles Whitehead 1234567890!\"£$%^&*()-=_+[];'#,./{}:@~<>?\\|`¬", 10.01f, 200.002f, 40000.00004f, 800000000.000000008f, true, false, true);

            Choice choiceOne = new Choice(scenarioTwo, "choiceText", "feedbackText", 0);

            scenarioOne.GetChoices().Add(choiceOne);

            Choice choicetwo = new Choice(scenarioOne, "Choice Two", "Very Good!", 1);
            Choice choicethree = new Choice(scenarioThree, "Choice Three", "Very Bad!", -1);

            scenarioTwo.GetChoices().Add(choicetwo);
            scenarioTwo.GetChoices().Add(choicethree);

            string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum";

            Choice choicefour = new Choice(scenarioOne, loremIpsum, loremIpsum, 999);
            Choice choicefive = new Choice(scenarioTwo, loremIpsum, loremIpsum, 0);
            Choice choiceSix = new Choice(scenarioThree, loremIpsum, loremIpsum, -999);

            scenarioThree.GetChoices().Add(choicefour);
            scenarioThree.GetChoices().Add(choicefive);

            for (int i = 0; i < 10; i++)
            {
                scenarioThree.GetChoices().Add(choiceSix);
            }

            scenarioList.GetScenarios().Add(scenarioOne);
            scenarioList.GetScenarios().Add(scenarioTwo);
            scenarioList.GetScenarios().Add(scenarioThree);

            string json = string.Empty;

            JSONParser.TObjectToJSON(ref json, scenarioList);

            Console.WriteLine(json);

            ScenarioList jsonScenarioList = new ScenarioList();

            JSONParser.JSONToTObject(json, ref jsonScenarioList);

            Console.ReadLine();
        }
    }
}