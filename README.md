<a href="https://mod.io"><img src="https://static.mod.io/v1/images/branding/modio-color-dark.svg" alt="mod.io" width="400"/></a>

# :package: Modio.NET - mod.io API Client Library for .NET

![License][license-badge]
[![Workflow Status][workflow-badge]][actions-url]

[license-badge]: https://img.shields.io/badge/license-MIT%2FApache--2.0-blue
[workflow-badge]: https://github.com/nickelc/modio.net/workflows/CI/badge.svg
[actions-url]: https://github.com/nickelc/modio.net/actions?query=workflow%3ACI

### Examples

```csharp
using Modio;
using Modio.Filters;

var client = new Client(new Credentials("api-key"/*, "token"*/));

// Get game, mod and file objects
var game = await client.Games[5].Get();
var mod = await client.Games[5].Mods[110].Get();
var file = await client.Games[5].Mods[110].Files[395].Get();

// _limit=10&_offset=10
var filter = Filter.WithLimit(10).Offset(10);

// id-in=5,34,51&_sort=-id
var filter = GameFilter.Id.In(5, 34, 51)
    .And(GameFilter.Id.Desc());

IAsyncEnumerable<Game> games = client.Games.Search(filter).ToEnumerable();
await foreach (var game in games) {
    Console.WriteLine(game.Name);
}

// _q=balance&_limit=5&_sort=rating
var filter = ModFilter.FullText.Eq("balance")
    .Limit(5)
    .And(ModFilter.Rating.Desc());

IReadOnlyList<Mod> mods = await client.Games[5].Mods.Search(filter).ToList();
foreach (var mod in mods) {
    Console.WriteLine(mod.Name);
}
```
