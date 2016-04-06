using Pharm.Core.Entities;
using Pharm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharm.Repository.HFRepository
{

    public class HFRepository:GRepository<HealthFacility>
    {
        public HFRepository(bool lazy):base(lazy)
        {

        }

        
        public HealthFacility GetHFByCode(string code)
        {
            var _result = GetAll().FirstOrDefault(x => x.Code == code);
            return _result;
        }
    }
}
