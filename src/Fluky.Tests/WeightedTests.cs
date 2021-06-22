using System.Collections.Generic;
using System.Linq;
using Fluky.Types;
using Shouldly;
using Xunit;

namespace Fluky.Tests
{
  public class WeightedTests
  {
    private readonly Randomizer _sut;

    public WeightedTests()
    {
      _sut = new Randomizer();
    }

    [Fact]
    public void Test()
    {
      // Arrange
      var list = new List<Player>();

      // Quarterbacks
      for (var i = 0; i < 20; i++)
      {
        var player = GeneratePlayer(30, 40, "Quarterback");
        list.Add(player);
      }

      // Running backs
      for (var i = 0; i < 20; i++)
      {
        var player = GeneratePlayer(10, 20, "Runningback");
        list.Add(player);
      }

      // Kickers
      for (var i = 0; i < 20; i++)
      {
        var player = GeneratePlayer(1, 2, "Kicker");
        list.Add(player);
      }

      // Act
      var results = new List<Player>();
      for (var i = 0; i < 40; i++)
      {
        var player = _sut.Choose(list);
        player.Position = i + 1;

        results.Add(player);
        list.Remove(player);
      }

      // Assert
      var quarterBacks = results.Where(x => x.PlayerType == "Quarterback").ToList();
      var runningBacks = results.Where(x => x.PlayerType == "Runningback").ToList();
      var kickers = results.Where(x => x.PlayerType == "Kicker").ToList();
      quarterBacks.Count.ShouldBeGreaterThanOrEqualTo(runningBacks.Count);
      runningBacks.Count.ShouldBeGreaterThanOrEqualTo(kickers.Count);

      var topTenQuarterBacks = quarterBacks.Count(x => x.Position <= 10);
      var topTenRunningBacks = runningBacks.Count(x => x.Position <= 10);
      var topTenKickers = kickers.Count(x => x.Position <= 10);
      topTenQuarterBacks.ShouldBeGreaterThan(topTenRunningBacks);
      topTenRunningBacks.ShouldBeGreaterThanOrEqualTo(topTenKickers);
    }

    private Player GeneratePlayer(int minWeight, int maxWeight, string type)
    {
      var weight = _sut.Natural(minWeight, maxWeight);
      var name = _sut.FirstName(GenderType.Male);
      var player = new Player(name, type, weight);

      return player;
    }

    private class Player : IWeighted
    {
      public Player(string name, string playerType, int weight)
      {
        Name = name;
        PlayerType = playerType;
        Weight = weight;
      }

      public string Name { get; }
      public string PlayerType { get; }
      public int Weight { get; set; }
      public int Position { get; set; }
    }
  }
}
