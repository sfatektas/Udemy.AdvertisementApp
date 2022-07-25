using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Advertisement.Entities
{
    public class Gender : BaseEntity
    {
        public string Defination  { get; set; }

        //Nav Prop 

        public List<AppUser> AppUsers { get; set; }
        
    }
}
