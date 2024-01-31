const schema = {
  bsonType: "object",
  required: ["name"],
  properties: {
    _id: {
      bsonType: "objectId"
    },
    name: {
      bsonType: "string"
    },
    is_deleted: {
      bsonType: "bool"
    }
  }
};

db.getSiblingDB('SkiService').createCollection("states", {
  validator: {
    $jsonSchema: schema
  }
});
