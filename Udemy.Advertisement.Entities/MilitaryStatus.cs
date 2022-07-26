using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Advertisement.Entities
{
    public class MilitaryStatus : BaseEntity
    {
        public string  Defination { get; set; }

        public List<AdvertisementAppUser> AdvertisementUsers{ get; set; }
    }
}
