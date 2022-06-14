using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public static void MapProperties(Entity entityFrom, Entity entityTo)
        {
            foreach (var from in entityFrom.GetType().GetProperties())
            {
                foreach (var to in entityTo.GetType().GetProperties())
                {
                    if (from.Name == to.Name && from.Name != "Id")
                    {
                        if (from.GetValue(entityFrom) != null)
                            to.SetValue(entityTo, from.GetValue(entityFrom));
                    }
                }
            }
        }
    }
}
