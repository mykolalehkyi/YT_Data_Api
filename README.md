# YouTube Data Api
Hi, I am Mykola Lehkyi and I am Software Engineer.
## Project Overview
YT Data Api is an ASP.NET Core Razor Pages application designed to fetch YouTube video statistics and snippets from a specified playlist. This application makes use of the YouTube Data API to pull data dynamically based on playlist IDs provided.

Azure part: https://github.com/mykolalehkyi/SaveYouTubeVideoStatistics/
Web Api part: https://github.com/mykolalehkyi/YT_Data_Api
Angular client part: https://github.com/mykolalehkyi/epz-youtube-api 

## Features
- Fetching videos from a YouTube playlist.
- Retrieving detailed statistics and snippet data for each video in the playlist.
- Dynamic API key management via environment variables.
## Prerequisites
- .NET 6.0 SDK or later
- An IDE like Visual Studio or VS Code
- A valid YouTube Data API key set in the environment variables
## Usage
The application is set up to trigger API calls to YouTube on accessing the home page (GET request). It will fetch videos from the specified playlist and display their statistics and snippet information. Adjust the playlist ID in the code to fetch different playlists.

## API Reference
- GetVideosFromPlaylist(string playlistId)
Fetches video items from a specified YouTube playlist.

Parameters: playlistId - The YouTube playlist ID.
Returns: A list of video items with content details.
- GetVideoStatistics(string videoId)
Fetches statistics and snippet data for a given YouTube video ID.

Parameters: videoId - The YouTube video ID.
Returns: Detailed statistics and snippet information for the video.
