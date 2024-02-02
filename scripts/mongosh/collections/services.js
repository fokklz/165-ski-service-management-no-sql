const schema = {
  bsonType: 'object',
  required: ['description', 'name', 'price'],
  properties: {
    _id: {
      bsonType: 'objectId',
    },
    description: {
      bsonType: 'string',
      minLength: 20,
    },
    name: {
      bsonType: 'string',
      minLength: 3,
    },
    price: {
      bsonType: 'int',
      minimum: 1,
      maximum: 1000,
    },
    is_deleted: {
      bsonType: 'bool',
    },
  },
};

db.getSiblingDB('SkiService').createCollection('services', {
  validator: {
    $jsonSchema: schema,
  },
});
