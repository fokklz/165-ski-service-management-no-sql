const schema = {
  bsonType: "object",
  required: ["description", "name", "price"],
  properties: {
    _id: {
      bsonType: "objectId"
    },
    description: {
      bsonType: "string"
    },
    name: {
      bsonType: "string"
    },
    price: {
      bsonType: "int"
    },
    is_deleted: {
      bsonType: "bool"
    }
  }
};

db.getSiblingDB('SkiService').createCollection("services", {
  validator: {
    $jsonSchema: schema
  }
});
