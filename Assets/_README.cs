using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class README : MonoBehaviour
{
    /// Notes
    /// 
    /// PacNumbers are the numbers that appear on each player - players try and get their numbers to zero, speed increases as pacnumber goes down - collide with a player who has a higher pacnumber you lose points
    ///     They are named for the brief period when this game was going to be set in Pacman-like mazes
    /// 
    /// PlayerScores are the big numbers at the top, win one if you get your pacNumber down to zero, biggest playerScore wins the game.
    /// 
    /// 
    /// 
    /// 
    /// 
    /// TO DO: 
    /// Sometimes more than one collectable spawns, but the extra ones are just 
    ///     sprites that can't be intereacted with; find out why and how to stop it
    /// Stop collectables spawning on walls - this is sort of self fixing at the moment as collectables will appear on a
    ///     wall then immediately disappear and a new one spawns, looks messy and sometimes they stay on a wall
    /// Stop collectables spawning on top of players
    /// Find way to spawn collectable not too near to last spawned collectable?
    /// 
    /// 
    /// When player speed increases player can sometimes pass through walls, partly fixed with use of raycasts which increase in length 
    ///     as speed increases, this seems to work better on some players than others, may be to do with how I've placed the raycasts in relation to player...
    /// Raycasts also cause issue with player movement sometimes becoming a bit sticky/jerky near walls
    /// 
    /// 
    /// Player controls aren't all that good, possible to have players bouncing around off walls like ice hockey pucks???
    /// 
    /// 
    /// Give player ability to quit game during level and go back to menu - using escape key and onscreen message asking if you definitely want to quit, maybe?
    /// 
    /// 
    /// Use spritearray to make colour of collectable change randomly on each respawn
    /// 
    /// Similarly have random selection of winscreen messages specific to each player
    /// Possible to allow players to imput names which appear in winscreen message?
    /// 
    /// Make winscreen messages look better
    /// 
    /// 
    /// Tidy up scripts, remove unnesscessary lines and rearrange to more logical order
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 


















}
