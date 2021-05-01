# CaveAdventure - A simple text based adventure game in C# .NET

Clone and run with ```dotnet run```

Small commandline based game written in C# .NET for the course DT071G.
Most games are cheatable by typing "cheat" instead of a response, all but the hangman.

## Startup
You choose a name and catchphrase at the start, then go on your adventure.

## House
Painting that's searchable. Gives hint about searching the graveyard.

## Graveyard
Search the gravestone to find the graveyard key.

## Tavern/Inn
Math minigame for mathkey, cheatable by typing "cheat" instead of response.
Hangman minigame for hangman key, look in dictionary of hangman file to cheat past this.
Billy has lost his dog Nessie, you can find her at the graveyard by saying "whistle". Then go back to billy and tell him she's at the graveyard.
Saga the bartender has no real purpose but to tell a hint, or sell a beer. You can pass out from drinking too much beer.

## Random encounter thief
You have a chance to stumble upon a thief that will play rock paper scissor with you when you go out of the bar.
You can also force this encounter by typing "thief" outside. You may cheat this encounter by typing "cheat".

## Cave
Open gate with 5 keys. You win the game if you do.

## Other notes
There are a couple of odd bits left in the game to give it more character, such as typing "die" outside to die.
The saving function is junk, but it works.
