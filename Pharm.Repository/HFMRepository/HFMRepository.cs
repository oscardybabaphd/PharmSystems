using Pharm.Core.Entities;
using Pharm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharm.Repository.HFMRepository
{
    public class HFMRepository : GRepository<HFManager>
    {
        public HFMRepository(bool lazy)
            : base(lazy)
        {

        }

        public List<HFManager> GetHFMByRegion(Region region)
        {
            return GetAll().Where(x => x.Region == region).ToList();
        }

        public List<HFManager> GetHFMByPagination(int pageIndex, int pageSize)
        {
            return GetByPagination(pageIndex, pageSize);
        }

    }
}
