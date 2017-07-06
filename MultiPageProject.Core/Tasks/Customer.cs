using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 IHasCreationTime : 创建时间
 ICreationAudited : 创建时间.创建人ID , 实现类:CreationAuditedEntity
 IAudited : 审计所有, 实现类:AuditedEntity
 ISoftDelete : 软删除. 实现类:IDeletionAudited
 IFullAudited 审计和创建所有 实现类:FullAuditedEntity

*/
namespace MultiPageProject.MyTasks {
    public class Customer : FullAuditedEntity {

        public string Title { get; set; }
        public int Desc { get; set; }
    }
}
