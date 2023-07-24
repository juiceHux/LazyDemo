using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [Table("device_info_relation")]
    public class DeviceInfoRelation : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       // 自增字段
        [Column("id")]
        public int Id { get; set; }

        [Column("devicekey")]
        public string DeviceKey { get; set; }

        [Column("cid")]
        public string Cid { get; set; }

        [Column("way")]
        public string Way { get; set; }

        [Column("modifytime")]
        public string ModifyTime { get; set; }
    }


    /// <summary>
    /// 实体基类
    /// </summary>
    public class Entity
    {
        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
