using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using YT_Data_Api.Models;

namespace YT_Data_Api.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async void OnGet()
        {
            List<YouTubeStatisticsSnippetModel> videoModels = new List<YouTubeStatisticsSnippetModel>();
            var videos = await GetVideosFromPlaylist("PLln3PF6nQloueB1D4nhqg3j4Yl-ggS9vo");
            for (int i = 0; i < videos.items.Count; i++)
            {
                var video = videos.items[i];
                var videoModel = await GetVideoStatistics(video.contentDetails.videoId);
                videoModels.Add(videoModel);
            }
        }

        private async Task<YouTubePlaylistModel> GetVideosFromPlaylist(string playlistId)
        {
            var parameter = new Dictionary<string, string>
            {
                ["key"] = Environment.GetEnvironmentVariable("YoutubeDataApiKey"),
                ["playlistId"] = playlistId,
                ["part"] = "contentDetails",
                ["maxResults"] = "3"
            };

            var baseUrl = "https://www.googleapis.com/youtube/v3/playlistItems?";
            var fullUrl = MakeURLFromQuery(baseUrl, parameter);

            var result = await new HttpClient().GetStringAsync(fullUrl);

            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<YouTubePlaylistModel>(result);
            }

            return null;
        }

        private async Task<YouTubeStatisticsSnippetModel?> GetVideoStatistics(string videoId)
        {
            var parameter = new Dictionary<string, string>
            {
                ["key"] = Environment.GetEnvironmentVariable("YoutubeDataApiKey"),
                ["part"] = "statistics&part=snippet",
                ["id"] = videoId,
            };

            var baseUrl = "https://youtube.googleapis.com/youtube/v3/videos?";
            var fullUrl = MakeURLFromQuery(baseUrl, parameter);

            var result = await new HttpClient().GetStringAsync(fullUrl);

            if (!string.IsNullOrEmpty(result))
            {
                return JsonConvert.DeserializeObject<YouTubeStatisticsSnippetModel>(result);
            }

            return null;
        }

        private string MakeURLFromQuery(string baseUrl, Dictionary<string, string> parameter)
        {
            return parameter.Aggregate(baseUrl, (accumulated, par) => string.Format($"{accumulated}{par.Key}={par.Value}&"));
        }
    }
}