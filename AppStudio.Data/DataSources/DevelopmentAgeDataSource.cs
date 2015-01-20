using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class DevelopmentAgeDataSource : DataSourceBase<DevelopmentAgeSchema>
    {
        private const string _file = "/Assets/Data/DevelopmentAgeDataSource.json";

        protected override string CacheKey
        {
            get { return "DevelopmentAgeDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<DevelopmentAgeSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<DevelopmentAgeSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("DevelopmentAgeDataSource.LoadData", ex.ToString());
                return new DevelopmentAgeSchema[0];
            }
        }
    }
}
