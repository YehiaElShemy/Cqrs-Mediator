using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs_Mediator.InfraStructure.InfraStructureConfigrations.SettingSystem
{
    public class FileConfig
    {
        public List<string> fileExtention { get; set; }
        public double maxSizeFile { get; set; }
        public string fileUnit { get; set; }
        public bool enbleCompresstion { get; set; }
 
    }
}
