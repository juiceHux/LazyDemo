using Services;
using System;
using System.Linq;

namespace demo
{
    public class Program
    {
        private static readonly LazyService<EntityService<DeviceInfoRelation>> DeviceInfoRelationEs = new LazyService<EntityService<DeviceInfoRelation>>();

        //private static readonly LazyService<EntityService<DeviceInfoRelation>> CbContractGroupEntityService = new LazyService<EntityService<DeviceInfoRelation>>(() => new EntityService<DeviceInfoRelation>());

        private static readonly LazyService<EntityService<DeviceInfoRelation>> CbContractGroupEntityService = new LazyService<EntityService<DeviceInfoRelation>>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var list = _deviceInfoRelationEs.Instance.GetAllAsync().ToList();

            var list = CbContractGroupEntityService.Instance.GetAllAsync().ToList();

            if (list.Any())
            {
                Console.WriteLine($"查出行数：{list.Count()}");


                var item = CbContractGroupEntityService.Instance.Find(x=>x.Cid == "1");
                Console.WriteLine(item.FirstOrDefault()?.DeviceKey);


                var data = CbContractGroupEntityService.Instance.FirstOrDefaultNoTracking(x => x.Id == 10);
                data.Way = "";
                data.ModifyTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                var count = CbContractGroupEntityService.Instance.Update(data);
                Console.WriteLine($"更新返回：{count}");

                var dataNoAc = CbContractGroupEntityService.Instance.FirstOrDefault(x => x.Id == 10);
                dataNoAc.Way = "";
                dataNoAc.ModifyTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                var count2 = CbContractGroupEntityService.Instance.Update(dataNoAc);
                Console.WriteLine($"2更新返回：{count2}");

            }

            Console.ReadLine();
        }
    }
}
