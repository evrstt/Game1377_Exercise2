/*
 * Assignment: Monster Brawl
 * 
 * Objective:
 * Implement a battle simulation in the Start method. You are given five monsters, each with a name, attack stat, health stat and speed stat. 
 *      Attack determines how much damage it does when it attacks. Health determines how much damage it can take before dying.
 *      Speed determines how often a monster attacks (1 means it attacks every turn, 2 means every 2 turns, 3 means every 3 turns, and so on)
 *  
 *  Print the roster
 *      1. Loop through the monsters and print each one in this exact format:
 *      Goblin | ATK: 8 | HP: 30 | SPD: 1
 *  
 *  Simulate every unique 1v1 fight
 *      1. Every monster should fight every other monster exactly once.
 *          Goblin vs Orc and Orc vs Goblin are the same fight � only one should occur.
 *      2. A monster should never fight itself.
 *      3. In each fight, both monsters attack simultaneously each turn.
 *      4. A monster only attacks on turns that are a multiple of its speed.
 *          E.g. a monster with speed 2 attacks on turns 2, 4, 6, etc. A monster with speed 3 attacks on turns 3, 6, 9, etc.
 *      5. The fight ends when one or both monsters reach 0 HP or below.
 *      6. Print each fight result in this exact format:
 *          Goblin vs Orc | Winner: Orc | Turns: 12 | Remaining HP: 24
 *      7. If both monsters die on the same turn, print:
 *          Goblin vs Orc | Draw | Turns: 8
 *  Instructions:
 *      Attach the script to any active GameObject in your Unity scene.
 *      Observe the results in the Console after hitting the Play button.
 */

using UnityEngine;

public class MonsterBrawl : MonoBehaviour
{
    void Start()
    {
        string[] monsterNames = { "Goblin", "Orc", "Troll", "Skeleton", "Ogre" };
        int[] attackStats = { 8, 20, 35, 12, 50 };
        int[] healthStats = { 30, 80, 200, 50, 250 };
        int[] speedStats = { 1, 2, 3, 1, 4 };


        
        // This Prints Each Monster's name and Stats to console by using the this for loop to print each index for our string and 3 ints in order until it int i is = to the length of monsterName
        // (or any of the int arrays for that matter)

        for (int i = 0; i < monsterNames.Length; i++)
        {
            Debug.Log(monsterNames[i] + " | ATK: " + attackStats[i] + " | HP: " + healthStats[i] + " | SPD: " + speedStats[i]);
        }


        // This for loop runs all of the fights, running Goblin (or 0) against all the remaining Monsters before adding to i then repeating so that none of the monsters fight twice 
        // (because the inner loop ends once it reaches the end of its index)
        for (int i = 0; i < monsterNames.Length; i++)
        {
            for (int j = i + 1; j < monsterNames.Length; j++)
            {
                string monsterAName = monsterNames[i];
                string monsterBName = monsterNames[j];

                int monsterAAttack = attackStats[i];
                int monsterBAttack = attackStats[j];

                int monsterAHealth = healthStats[i];
                int monsterBHealth = healthStats[j];
                
                int monsterASpeed = speedStats[i];
                int monsterBSpeed = speedStats[j];

                int turn = 0;

                while (monsterAHealth > 0 && monsterBHealth > 0)
                {
                    turn++;

                    // these two bools takes the turn value and and checks if it can be divided evenly by the current monster's speed (IE it equals 0) and as long as its true it will attack
                    // this is so the monsters attack on their appropriate turn, ie even on even and odd on odd 

                    bool monsterAAttacks = turn % monsterASpeed == 0;
                    bool MonsterBAttacks = turn % monsterBSpeed == 0;

                    if (monsterAAttacks)
                    {
                        monsterBHealth-= monsterAAttack;
                    }

                    if (MonsterBAttacks)
                    {
                        monsterAHealth -= monsterBAttack;
                    }
                }

                // this section prints each fight and outcome to the console, printing ties first, followed by any Monster A wins via the else if loop, then else for any remaining battles, ie monster B Wins.
                if (monsterAHealth <= 0 && monsterBHealth <= 0)
                {
                    Debug.Log(monsterAName + " vs " + monsterBName + " | Draw | Turns: " + turn);
                }

                else if (monsterAHealth > 0)
                {
                    Debug.Log(monsterAName + " vs " + monsterBName + " | Winner: " + monsterAName + " | Turns: " + turn + " | Remaining HP: " + monsterAHealth);
                }

                else
                {
                    Debug.Log(monsterAName + " vs " + monsterBName + " | Winner: " + monsterBName + " | Turns: " + turn + " | Remaining HP: " + monsterBHealth);
                }

            }
        }
    }
}

