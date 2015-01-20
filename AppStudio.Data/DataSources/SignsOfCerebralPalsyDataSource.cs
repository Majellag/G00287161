using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class SignsOfCerebralPalsyDataSource : DataSourceBase<SignsOfCerebralPalsySchema>
    {
        private const string _file = "/Assets/Data/SignsOfCerebralPalsyDataSource.json";

        protected override string CacheKey
        {
            get { return "SignsOfCerebralPalsyDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<SignsOfCerebralPalsySchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<SignsOfCerebralPalsySchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("SignsOfCerebralPalsyDataSource.LoadData", ex.ToString());
                return new SignsOfCerebralPalsySchema[0];
            }
        }
    }
}
