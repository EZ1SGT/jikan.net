﻿using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JikanDotNet.Tests
{
	public class PersonSearchTestClass
	{
		private readonly IJikan jikan;

		public PersonSearchTestClass()
		{
			jikan = new Jikan();
		}

		[Theory]
		[InlineData("araki")]
		[InlineData("oda")]
		[InlineData("sawashiro")]
		public async Task SearchPerson_NonEmptyQuery_ShouldReturnNotNullSearchPerson(string query)
		{
			PersonSearchResult returnedPerson = await jikan.SearchPerson(query);

			Assert.NotNull(returnedPerson);
		}

		[Fact]
		public async Task SearchPerson_MaayaSakamotoQuery_ShouldReturnSakamoto()
		{
			PersonSearchResult returnedPerson = await jikan.SearchPerson("maaya sakamoto");

			Assert.Single(returnedPerson.Results);
		}

		[Fact]
		public async Task SearchPerson_MaayaSakamotoQuery_ShouldReturnSakamotoName()
		{
			PersonSearchResult returnedPerson = await jikan.SearchPerson("maaya sakamoto");

			Assert.Equal("Maaya Sakamoto", returnedPerson.Results.First().Name);
		}

		[Fact]
		public async Task SearchPerson_MaayaSakamotoQuery_ShouldReturnSakamotoMalId()
		{
			PersonSearchResult returnedPerson = await jikan.SearchPerson("maaya sakamoto");

			Assert.Equal(90, returnedPerson.Results.First().MalId);
		}

		[Fact]
		public async Task SearchPerson_DaisukeQuerySecondPage_ShouldReturnDaisuke()
		{
			PersonSearchResult returnedPerson = await jikan.SearchPerson("daisuke", 2);

			Assert.Equal(50, returnedPerson.Results.Count);
			Assert.Contains("Daisuke", returnedPerson.Results.Select(x => x.Name));
		}
	}
}