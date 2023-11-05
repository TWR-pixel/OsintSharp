﻿using OsintSharp.Core;
using OsintSharp.Core.Factories;
using OsintSharp.Core.Json;
using OsintSharp.Ui.Cli;
using System.Collections.Concurrent;

//var cl = new HttpClientHelperFactory().Create();
//var r = await cl._httpClient.GetStringAsync("https://api.ipify.org/");

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine(Settings.Hello);
Console.ResetColor();

Console.Write("Enter username: ");
var username = Console.ReadLine();

var httpClientHelperFactory = new HttpClientHelperFactory();

var userForSearch = new UserForSearch(username);

var urlsDictionary = await JsonUrlDeserialization.DeserializeAync("Resources\\urls.json");
var urls = new ConcurrentBag<string>();
var socialNetwork = new SocialNetwork(httpClientHelperFactory.Create());

foreach (var i in urlsDictionary)
{
    urls.Add(i.Value.Url.Replace("{}", userForSearch.UserName, true, null));
}

await socialNetwork.StartAnalysisAsync(HttpMethods.GET, urls);

Console.ReadLine();