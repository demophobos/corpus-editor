using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Property
{
    public class HeaderPropertyModel
    {
        [Browsable(false)]
        public string Id { get; set; }
        [DisplayName("Код")]
        public string Code { get; set; }
        [DisplayName("Издание")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Desc { get; set; }
        [DisplayName("Язык")]
        public string Lang { get; set; }
        [DisplayName("Тип издания")]
        public string EditionType { get; set; }
        [Browsable(false)]
        public string ProjectId { get; set; }
        [DisplayName("Статус")]
        public string Status { get; set; }

        public HeaderPropertyModel(HeaderModel headerModel)
        {
            Id = headerModel.Id;
            Code = headerModel.Code;
            Desc = headerModel.Desc;
            Lang = headerModel.Lang;
            EditionType = headerModel.EditionType;
            Status = headerModel.Status;
        }
    }
}
