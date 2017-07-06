using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPageProject.DTOMappping {
    public interface IDtoMapping {
        void CreateMapping(IMapperConfigurationExpression mapperConfig);
    }
}
