using SushiBarBusinessLogic.OfficePackage.HelperEnums;
using System.Collections.Generic;

namespace SushiBarBusinessLogic.OfficePackage.HelperModels
{
    public class PdfRowParameters
    {
        public List<string> Texts { get; set; }
        public string Style { get; set; }
        public PdfParagraphAlignmentType ParagraphAlignment { get; set; }
    }
}