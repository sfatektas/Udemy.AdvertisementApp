using System;

namespace DI_deneme.Controllers
{
    public interface IScoped
    {
        public Guid Guid { get; set; }
    }
}