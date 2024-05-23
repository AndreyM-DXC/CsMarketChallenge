# C# Coding Challenge #6: Market Competition

Discounts attract customers and you can make money on this by luring away your opponent’s customers. But if everyone makes discounts, then why should the buyer come to you?

![](https://github.com/AndreyM-DXC/CsMarketChallenge/blob/master/banner.png?raw=true)

**Task:** Earn as much money as possible!

**Rules:**
* Each participant can send **up to 5 **bot implementations.
* The tournament consists of all pairs of bots of all participants, including games with itself.
* The game consists of 365 turns, each turn two players independently decide to make a discount or not:
   * If both decide not to make a discount, then each gets 3 points.
   * If both decide to make a discount, then each gets 1 point.
   * If only one of the players makes a discount, then he gets 5 points and the opponent gets nothing.
* Bot with the most sum of score points in the tournament wins.

**How to play:**

You can find the source code of Market Competition game on GitHub:
[https://github.com/AndreyM-DXC/CsMarketChallenge](https://github.com/AndreyM-DXC/CsMarketChallenge)

It contains all the game logics and sample bot:
* `RandomPlayer` - minimal bot example.

The code is divided into two projects:
* Console application to simulate tournament.
* Windows forms application to visualize a single game.

**Goal:**

Implement the `IPlayer` interface so that the bot can play on its own and finish the game in reasonable time.

Feel free to use external libraries, but keep in mind that bot should be simple to assemble. 🤓

Please, share your solution with us via the mail (You can either attach an archive with the source code or share a link to public GitHub repository).

You can submit solutions till 3th of June EOD.