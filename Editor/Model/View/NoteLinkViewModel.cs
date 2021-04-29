using Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.View
{
    public class NoteLinkViewModel : NoteLinkModel
    {
        public string TargetCode { get { return NoteTargetEnum.GetById(Target.ToString()).Code; } }

        public string NoteValue { get; set; }

        public string ItemName { get; set; }
    }
}
