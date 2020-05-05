using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyAdministration.Core.Extentions
{
    public static class TablesQueryableExtensions
    {
        public static IEnumerable<House> SearchName(this IEnumerable<House> port, string searchname)
        {
            var res =  port.Where(r => searchname == null || 
                        r.StreetName.ToUpper().Contains(searchname.ToUpper()) ||
                        r.Owner.FullName.ToUpper().Contains(searchname.ToUpper()));

            //if(res.Count() == 0)
            //    res = port.Where(r => searchname == null || r.Owner.FullName.ToUpper().Contains(searchname.ToUpper()));

            return res;
        }

        //public static IQueryable<Security_Detail> SearchSecName(this IQueryable<Security_Detail> port, string searchname)
        //{
        //    return port.Where(r => searchname == null || r.Security_Name.Contains(searchname));
        //}
    }
}

