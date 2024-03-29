﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Users.API.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }
    }
}
