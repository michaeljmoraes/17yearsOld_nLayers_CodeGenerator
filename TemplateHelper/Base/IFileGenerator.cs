using System.Text;

namespace ProductivityTools.CodeGenerator.TemplateHelper.Base
{
    public interface IFileGenerator
    {
        StringBuilder MergeTemplate();
        bool SaveToFile();
        void SetTemplateFile();
    }
}
