## 31.07.2019 - Version 1.3.0 (newest)

- Integration with Jikan API v3.3.
- Features
    - <b>[Search]</b> Improved searching for manga and anime
        - Order by data (Title, score, etc.)
        - Filter Producer (anime) or Magazine (manga)
        - Improved multiple genre query.
    - <b>[UserList]</b> Advanced User Lists (Anime/Manga) queries
        - Usable by passing `UserListAnimeSearchConfig` to `GetUserAnimeList` and `UserListMangaSearchConfig`to `GetUserMangaList` methods
            - Order by data: `OrderBy`, `OrderBy2` (Title, score, etc.)
            - Sort by ascending/descending - `SortBy`
            - Search user list: `Query` property
            - New Anime filters: `Producer`, `Season`, `Year`, `AiringStatus`
            - New Manga filters: `Magazine`, `PublishingStatus`
            - Paging support: `Page` property
- Fixes
    - <b>[AnimeEpisoded]</b> changed `Aired` property from `TimeSpan` (a pair of `DateTime`) to single `DateTime`

## 07.04.2019 - Version 1.2.5 (newest)

- Jikan.net now can be used with own instance of Jikan REST API. Read more [here](https://github.com/Ervie/jikan.net/wiki/Using-own-instance-of-Jikan).
- New fields
    - RelatedAnime
        - `RelatedAnime` now has `AlternativeVersions`, `ParentStories` and `FullStories` fields.
    - RelatedManga
        - `RelatedManga` now has `AlternativeVersions`, `ParentStories` and `FullStories` fields.

## 17.03.2019 - Version 1.2.4

- Fixes
    - <b>[Recommendation]</b> Added missing `Title` field.
    - <b>[AiringStatus]</b> Fixed PlanToWatch/PlanToRead values (in 1.2.4).
- New fields
    - AnimeList
        - `AnimeListEntry` now has `AiringStatus` and `PublishingStatus` fields.
    - MangaList
        - `MangaListEntry` now has `ReadingStatus` and `WatchingStatus` fields.

## 06.01.2019 - Version 1.2.2

- `Jikan` class has parameterless contructor now, which makes requests over HTTPS by default.
- New class `BaseJikanRequest` with cache related properties is now inherited by all main classes returned from wrapper methods (search request only in version 1.2.2).

## 01.01.2019 - Version 1.2.0 

- Integration with Jikan API v3.2.
- New endpoints
    - Anime
        - Reviews
        - Recommendations
        - User Updates
    - Manga
        - Reviews
        - Recommendations
        - User Updates
    - Season schedule with undefined date, marked as "Later" on MAL.
- Fixes
    - <b>[Anime]</b> Removed obsolete `EpisodeNumber` from `AnimeEpisode` class.
    - <b>[Anime]/[Manga]</b> `Related` field is deserialized properly when empty (fix in REST API).
- Other
    - All data from user related endpoints are now cached for 5 minutes only.
    - MAL entities with their own MAL Id now share `IMalEntity` interface.

## 23.11.2018 - Version 1.1.0 

- Integration with Jikan API v3
- New endpoints
    - Genre
        - Anime genres
        - Manga genres
    - Producer
    - Magazine
    - User
        - Profile
        - Friends
        - History
            - Filter by Anime/Manga.
        - Anime list
            - Filter by status (watching, completed, etc.)
            - Paging support
        - Manga list
            - Filter by status (reading, completed, etc.)
            - Paging support
    - Meta
        - API status
    - Top
        - People Top.
        - Characters Top.
    - Season Archive
- Extensions are no longer supported due to changes in REST API. Each type of extension now has separate method. Example:
    - Previously:
        - GetAnime(id) -> returns basic information about anime.
        - GetAnime(id, AnimeExtension.CharactersStaff) -> return basic information and characters/staff.
    - Currently:
        - GetAnime(id) -> returns basic information about anime.
        - GetAnimeCharactersStaff(id) -> return characters/staff of anime.
- <b>[Search]</b> Status enum renamed to AiringStatus
- <b>[Anime]</b>
    - Removed `AiredString`
    - `Pictures` is now collection of `Picture` type.
    - `StaffPositionEntry.Role` is now a collection.
    - `ForumPostSnippet.DateRelatice` is now DateTime.
- <b>[Manga]</b>
    - Removed `PublishedString`
    - `TitleSynonyms` are now a collection.
    - `Pictures` is now collection of `Picture` type.
    - `Authors`, `Genres` and `Serializations` are now `MALSubItem` collections.
- <b>[Character]</b>
    - `Nicknames` are now a collection.
    - `Images` got renamed to `Pictures` and now are collection of `Picture` type.
- <b>[Person]</b>
    - `Birthday` is now DateTime.
    - `Images` got renamed to `Pictures` and now are collection of `Picture` type.
- <b>[AnimeSearch]</b>
    - Add `Airing`, `StartDate`, `EndDate` and `Rated` data.
- <b>[MangaSearch]</b>
    - Add `Publishing`, `StartDate`, `EndDate` and `Chapters` data.
- <b>[CharactersSearch]</b>
    - `Nicknames` are now a collection.
- <b>[PersonSearch]</b>
    - `Nicknames` got renamed to `AlternativeNames` and are now a collection.
- <b>[Schedule]</b>
    - Filtering by day of the week is enabled now.

## 27.05.2018 - Version 1.0.3

- <b>[Season]</b> Add `SeasonName` and `SeasonYear` data.

## 20.05.2018 - Version 1.0.2 

- <b>[Character|Person]</b> Added add role info in animeography and mangaography (Character) and voice acting roles (Person).
- <b>[Season]</b> Added "type" and "continued" properties for season entry.

## 15.05.2018 - Version 1.0.1

- Fixed issue [#1](https://github.com/Ervie/jikan.net/issues/1) - error during parsing anime/manga with no related entries.

## 14.05.2018 - Version 1.0.0

- Requests for searching on MyAnimeList
- More overload methods.
- Initial version, up to date with Jikan API.

## 08.05.2018 - Version 0.3.0 

- Request for season preview.
- Request for anime schedule of current season.
- Request for Top Manga & Anime.

## 05.05.2018 - Version 0.2.0

- Extended request for Anime/Manga/Character/Person via extensions.

## 02.05.2018 - Version 0.1.0 

- First usable version.
- Added basic requests for Anime/Manga/Person/Character.