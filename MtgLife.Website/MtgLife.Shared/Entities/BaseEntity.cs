using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MtgLife.Shared.Entities
{
    public class BaseEntity
    {
        [BsonId]
        public ObjectId _id { get; set; }
    }
}
