﻿using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JikanDotNet.Tests
{
	public class ScheduleTestClass
	{
		private readonly IJikan jikan;

		public ScheduleTestClass()
		{
			jikan = new Jikan(true);
		}

		[Fact]
		public void ShouldParseCurrentSchedule()
		{
			Schedule currentSeason = Task.Run(() => jikan.GetSchedule()).Result;

			Assert.NotNull(currentSeason);
		}

		[Fact]
		public void ShouldParseMondaySchedule()
		{
			Schedule currentSeason = Task.Run(() => jikan.GetSchedule(ScheduledDay.Monday)).Result;

			Assert.Contains("Dororo", currentSeason.Monday.Select(x => x.Title));
			Assert.Contains("Mayonaka no Occult Koumuin", currentSeason.Monday.Select(x => x.Title));
		}

		[Fact]
		public void ShouldParseFridaySchedule()
		{
			Schedule currentSeason = Task.Run(() => jikan.GetSchedule(ScheduledDay.Friday)).Result;

			Assert.Contains("Doraemon (2005)", currentSeason.Friday.Select(x => x.Title));
			Assert.Contains("Crayon Shin-chan", currentSeason.Friday.Select(x => x.Title));
		}
		[Fact]
		public void ShouldParseUnknownSchedule()
		{
			Schedule currentSeason = Task.Run(() => jikan.GetSchedule(ScheduledDay.Unknown)).Result;

			Assert.Contains("Yodel no Onna", currentSeason.Unknown.Select(x => x.Title));
			Assert.Contains("Jinxiu Shenzhou Zhi Qi You Ji", currentSeason.Unknown.Select(x => x.Title));
		}

	}
}