using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class VideosDataSource : DataSourceBase<YouTubeSchema>
    {
        private const string _url = @"https://gdata.youtube.com/feeds/api/playlists/PLE42227BA4617A122?v=2";

        protected override string CacheKey
        {
            get { return "VideosDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<YouTubeSchema>> LoadDataAsync()
        {
            try
            {
                var youTubeDataProvider = new YouTubeDataProvider(_url);
                return await youTubeDataProvider.Load();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("VideosDataSourceDataSource.LoadData", ex.ToString());
                return new YouTubeSchema[0];
            }
        }
    }
}
