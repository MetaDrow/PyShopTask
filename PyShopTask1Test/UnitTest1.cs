using System;
using Xunit;
using Task1;

namespace PyShopGameTaskTest
{
	public class GetScoreTest
	{
		private Game GameStampTest ()
		{
			const int arrayLength = 5;

			GameStamp[] stamp = new GameStamp[arrayLength];
			var value1 = stamp[1].offset = stamp[1].score.home = stamp[1].score.away = 4;
			var value2 = stamp[2].offset = 7;
			var value3 = stamp[3].offset = 5;
			var value4 = stamp[4].offset = 1;

			var game = new Game(stamp);

			return game;
		}



		[Fact]
		public void ItShould_check_that_GetScore_is_works () // actual score return
		{
			//Arragne
			int offset = 1;

			Score scoreExp = new Score();
			var exp = scoreExp.home = scoreExp.away = 4;

			var game = GameStampTest();

			//Act
			var scoreAct = game.GetScore(offset);

			// Assert
			Assert.Equal(scoreExp, scoreAct);
		}


		[Theory]
		[InlineData(0)]
		[InlineData(5)]
		[InlineData(7)]
		[InlineData(6)]
		public void ItShould_check_(int offsetValue) // is work
		{
			//Arragne
			Score scoreExp = new Score();
			var game = GameStampTest();

			//Act
			var scoreAct = game.GetScore(offsetValue);

			// Assert
			Assert.Equal(scoreExp, scoreAct);
		}



		[Theory]
		[InlineData(-1)]
		[InlineData(10)]
		public void ItShould_check_IndexOutOfRangeException (int offset)
		{
			//Arragne
			Game check = GameStampTest();

			//Act
			Action testExep = () => check.GetScore(offset);

			// Assert
			Assert.Throws<IndexOutOfRangeException>(testExep);
		}
	}
}