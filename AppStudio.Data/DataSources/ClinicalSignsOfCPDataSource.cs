using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class ClinicalSignsOfCPDataSource : DataSourceBase<ClinicalSignsOfCPSchema>
    {
        private const string _file = "/Assets/Data/ClinicalSignsOfCPDataSource.json";

        protected override string CacheKey
        {
            get { return "ClinicalSignsOfCPDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<ClinicalSignsOfCPSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<ClinicalSignsOfCPSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("ClinicalSignsOfCPDataSource.LoadData", ex.ToString());
                return new ClinicalSignsOfCPSchema[0];
            }
        }
    }
}
