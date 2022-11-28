using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procwork.CodeGenerator.TemplateHelper.Base
{
    public interface IFileGenerator 
    {
        StringBuilder MergeTemplate();
        bool SaveToFile();
        void SetTemplateFile();
    }
}
