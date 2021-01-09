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
    public class ProjectPropertyModel
    {
        [Browsable(false)]
        public string Id { get; set; }
        [DisplayName("Код")]
        public string Code { get; set; }
        [DisplayName("Описание")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Desc { get; set; }
        [Browsable(false)]
        public string CreatorId { get; set; }
        [DisplayName("Создатель")]
        public string Creator { get; set; }
        [DisplayName("Дата создания")]
        public DateTime Created { get; set; }
        [DisplayName("Статус")]
        public string Status { get; set; }

        public ProjectPropertyModel(ProjectModel projectModel, UserModel userModel)
        {
            Id = projectModel.Id;
            Code = projectModel.Code;
            Desc = projectModel.Desc;
            Creator = userModel.Email;
            Status = projectModel.Status;
            Created = projectModel.Created;
        }
    }
}
